using EventBus.Base;
using EventBus.Base.Events;
using Microsoft.Azure.ServiceBus;
using Microsoft.Azure.ServiceBus.Management;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.AzureServiceBus
{
    public class EventBusServiceBus : BaseEventBus
    {
        private ITopicClient _topicClient;
        private ManagementClient _managementClient;
        private ILogger? _logger;

        public EventBusServiceBus(IServiceProvider serviceProvider, EventBusConfig eventBusConfig) : base(serviceProvider, eventBusConfig)
        {
            _managementClient = new(eventBusConfig.EventBusConnectionString);
            _topicClient = CreateTopicClient().GetAwaiter().GetResult();
            _logger = serviceProvider.GetService(typeof(ILogger<EventBusServiceBus>)) as ILogger<EventBusServiceBus>;
        }

        private async Task<ITopicClient> CreateTopicClient()
        {
            if (_topicClient == null || _topicClient.IsClosedOrClosing)
            {
                _topicClient = new TopicClient(EventBusConfig.EventBusConnectionString, EventBusConfig.DefaultTopicName, RetryPolicy.Default);
            }

            if (_managementClient != null && !await _managementClient.TopicExistsAsync(EventBusConfig.DefaultTopicName))
            {
                await _managementClient.CreateTopicAsync(EventBusConfig.DefaultTopicName);
            }

            return _topicClient;
        }

        public override async Task Publish(IntegrationEvent @event)
        {
            var eventName = @event.GetType().Name;
            eventName = ProcessEventName(eventName);

            var eventStr = JsonConvert.SerializeObject(@event);
            var bodyArr = Encoding.UTF8.GetBytes(eventStr);

            var message = new Message()
            {
                MessageId = Guid.NewGuid().ToString(),
                Body = bodyArr,
                Label = eventName,
            };

            await _topicClient.SendAsync(message);
        }

        public override async Task Subscribe<T, TH>()
        {
            var eventName = typeof(T).Name;
            eventName = ProcessEventName(eventName);

            if (!SubscriptionService.HasSubscriptionsForEvent(eventName))
            {
                var subscriptionClient = await CreateSubscriptionClientIfNotExists(eventName);

                RegisterSubscriptionClientMessageHandler(subscriptionClient);
            }
            _logger?.LogInformation("Subscribing to event {EventName} with {EventHandler}", eventName, typeof(TH).Name);

            SubscriptionService.AddSubscription<T, TH>();

        }

        public override async Task UnSubscribe<T, TH>()
        {
            var eventName = typeof(T).Name;

            try
            {
                var subscriptionClient = CreateSubscriptionClient(eventName);

                await subscriptionClient.RemoveRuleAsync(eventName);
            }
            catch (MessagingEntityNotFoundException)
            {
                _logger?.LogWarning("The messaging entity {EventName} could not be found", eventName);
            }

            _logger?.LogInformation("Unsubscribing from event {EventName}", eventName);

            SubscriptionService.RemoveSubscription<T, TH>();
        }

        private async Task<ISubscriptionClient> CreateSubscriptionClientIfNotExists(string eventName)
        {
            var subClient = CreateSubscriptionClient(eventName);
            var exists = _managementClient != null && await _managementClient.SubscriptionExistsAsync(EventBusConfig.DefaultTopicName, GetSubName(eventName));

            if (!exists && _managementClient != null)
            {
                await _managementClient.CreateSubscriptionAsync(EventBusConfig.DefaultTopicName, GetSubName(eventName));
                await RemoveDefaultRule(subClient);
            }

            await CreateRuleIfNotExists(eventName, subClient);

            return subClient;
        }

        private async Task RemoveDefaultRule(SubscriptionClient subscriptionClient)
        {
            try
            {
                await subscriptionClient.RemoveRuleAsync(RuleDescription.DefaultRuleName);
            }
            catch (Exception)
            {
                _logger?.LogWarning("The messaging entity {DefaultRuleName} could not be found", RuleDescription.DefaultRuleName);
            }
        }

        private async Task CreateRuleIfNotExists(string eventName, ISubscriptionClient subscriptionClient)
        {
            bool ruleExists;

            try
            {
                var rule = await _managementClient.GetRuleAsync(EventBusConfig.DefaultTopicName, GetSubName(eventName), eventName);
                ruleExists = rule != null;
            }
            catch (MessagingEntityNotFoundException)
            {
                ruleExists = false;
            }

            if (!ruleExists)
            {
                await subscriptionClient.AddRuleAsync(new RuleDescription()
                {
                    Filter = new CorrelationFilter() { Label = eventName },
                    Name = eventName
                });
            }
        }

        private SubscriptionClient CreateSubscriptionClient(string eventName)
        {
            return new SubscriptionClient(EventBusConfig.EventBusConnectionString, EventBusConfig.DefaultTopicName, GetSubName(eventName));
        }

        private void RegisterSubscriptionClientMessageHandler(ISubscriptionClient subscriptionClient)
        {
            subscriptionClient.RegisterMessageHandler(
                async (message, token) =>
                {
                    var eventName = $"{message.Label}";
                    var messageData = Encoding.UTF8.GetString(message.Body);

                    if (await ProcessEvent(ProcessEventName(eventName), messageData))
                    {
                        await subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
                    }
                },
                new MessageHandlerOptions(ExceptionReceivedHandler) { MaxConcurrentCalls = 10, AutoComplete = false }
                );
        }

        private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            var ex = exceptionReceivedEventArgs.Exception;
            var context = exceptionReceivedEventArgs.ExceptionReceivedContext;

            _logger?.LogError(ex, "Error handling Message: {ExceptionMessage} - Context: {@ExceptionContext}", ex.Message, context);

            return Task.CompletedTask;
        }

        public override void Dispose()
        {
            base.Dispose();

            _topicClient?.CloseAsync().GetAwaiter().GetResult();
            _managementClient?.CloseAsync().GetAwaiter().GetResult();
            _topicClient = null;
            _managementClient = null;
            GC.SuppressFinalize(this);
        }
    }
}
