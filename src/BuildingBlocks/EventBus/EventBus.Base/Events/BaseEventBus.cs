using EventBus.Base.Abstraction;
using EventBus.Base.SubManagers;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Base.Events
{
    public abstract class BaseEventBus : IEventBus
    {
        public readonly IServiceProvider ServiceProvider;
        public readonly IEventBusSubscriptionService SubscriptionService;
        public EventBusConfig EventBusConfig { get; set; }

        protected BaseEventBus(IServiceProvider serviceProvider, EventBusConfig eventBusConfig)
        {
            ServiceProvider = serviceProvider;
            SubscriptionService = new InMemoryEventBusSubscriptionManager(ProcessEventName);
            EventBusConfig = eventBusConfig;
        }

        public virtual string ProcessEventName(string eventName)
        {
            if (EventBusConfig.DeleteEventPrefix)
            {
                if (eventName.StartsWith(EventBusConfig.EventNamePrefix))
                {
                    string tempEventName = "";
                    for (int i = EventBusConfig.EventNamePrefix.Length; i < eventName.Length; i++)
                    {
                        tempEventName += eventName[i];
                    }
                    eventName = tempEventName;
                }
            }

            if (EventBusConfig.DeleteEventSuffix)
            {
                if (eventName.EndsWith(EventBusConfig.EventNameSuffix))
                {
                    string tempEventName = "";
                    for (int i = 0; i < eventName.Length - EventBusConfig.EventNameSuffix.Length; i++)
                    {
                        tempEventName += eventName[i];
                    }
                    eventName = tempEventName;
                }
            }

            return eventName;
        }

        public virtual string GetSubName(string eventName)
        {
            return $"{EventBusConfig.SubscriberClientAppName}.{ProcessEventName(eventName)}";
        }

        public virtual void Dispose()
        {
            EventBusConfig = null;
            SubscriptionService.Clear();
            GC.SuppressFinalize(this);
        }

        public async Task<bool> ProcessEvent(string eventName, string message)
        {
            eventName = ProcessEventName(eventName);

            var processed = false;

            if (SubscriptionService.HasSubscriptionsForEvent(eventName))
            {
                var subscriptions = SubscriptionService.GetHandlersForEvent(eventName);

                using (var scope = ServiceProvider.CreateScope())
                {
                    foreach (var subscription in subscriptions)
                    {
                        var handler = ServiceProvider.GetService(subscription.HandlerType);
                        if (handler == null) continue;

                        var eventType = SubscriptionService.GetEventTypeByName($"{EventBusConfig.EventNamePrefix}{eventName}{EventBusConfig.EventNameSuffix}");
                        if (eventType != null)
                        {
                            var integrationEvent = JsonConvert.DeserializeObject(message, eventType);
                            var concreteType = typeof(IIntegrationEventHandler<>).MakeGenericType(eventType);
                            await (Task)concreteType.GetMethod("Handle")?.Invoke(handler, new object[] { integrationEvent });
                        }
                    }
                }
                processed = true;
            }
            return processed;
        }

        public abstract Task Publish(IntegrationEvent @event);

        public abstract Task Subscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;

        public abstract Task UnSubscribe<T, TH>()
            where T : IntegrationEvent
            where TH : IIntegrationEventHandler<T>;
    }
}
