using EventBus.Base.Abstraction;
using EventBus.Base;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using EventBus.Factory;
using EventBus.UnitTest.Events;
using EventBus.UnitTest.EventHandlers;

namespace EventBus.UnitTest
{
    public class EventBusTests
    {
        private ServiceCollection _services;

        public EventBusTests()
        {
            _services = new ServiceCollection();
            _services.AddLogging(configure => configure.AddConsole());
        }

        [Test]
        public async Task subscribe_event_on_rabbitmq_test()
        {
            _services.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig eventBusConfig = GetRabbitMQConfig();
                return EventBusFactory.Create(eventBusConfig, sp);
            });
            var sp = _services.BuildServiceProvider();

            var eventBus = sp.GetRequiredService<IEventBus>();

            //await eventBus.Subscribe<TestCreatedIntegrationEvent, TestCreatedIntegrationEventHandler>();
            await eventBus.UnSubscribe<TestCreatedIntegrationEvent, TestCreatedIntegrationEventHandler>();
            Assert.Pass();
        }

        [Test]
        public async Task subscribe_event_on_azure_test()
        {
            _services.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig eventBusConfig = GetAzureConfig();
                return EventBusFactory.Create(eventBusConfig, sp);
            });
            var sp = _services.BuildServiceProvider();

            var eventBus = sp.GetRequiredService<IEventBus>();

            await eventBus.Subscribe<TestCreatedIntegrationEvent, TestCreatedIntegrationEventHandler>();
            await eventBus.UnSubscribe<TestCreatedIntegrationEvent, TestCreatedIntegrationEventHandler>();

            Assert.Pass();
        }

        [Test]
        public async Task send_message_to_rabbitmq()
        {
            _services.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig eventBusConfig = GetRabbitMQConfig();
                return EventBusFactory.Create(eventBusConfig, sp);
            });
            var sp = _services.BuildServiceProvider();

            var eventBus = sp.GetRequiredService<IEventBus>();

            await eventBus.Publish(new TestCreatedIntegrationEvent("Test Message"));
        }

        public async Task send_message_to_azure()
        {
            _services.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig eventBusConfig = GetAzureConfig();
                return EventBusFactory.Create(eventBusConfig, sp);
            });
            var sp = _services.BuildServiceProvider();

            var eventBus = sp.GetRequiredService<IEventBus>();

            await eventBus.Publish(new TestCreatedIntegrationEvent("Test Message"));
        }

        private EventBusConfig GetAzureConfig()
        {
            return new EventBusConfig()
            {
                ConnectionRetryCount = 5,
                SubscriberClientAppName = "EventBus.UnitTest",
                DefaultTopicName = "UniversityAssistantTopicName",
                EventBusType = EventBusConfig.EventBus.AzureServiceBus,
                EventNameSuffix = "IntegrationEvent",
                EventBusConnectionString = ""
            };
        }

        private EventBusConfig GetRabbitMQConfig()
        {
            return new EventBusConfig()
            {
                ConnectionRetryCount = 5,
                SubscriberClientAppName = "EventBus.UnitTest",
                DefaultTopicName = "UniversityAssistantTopicName",
                EventBusType = EventBusConfig.EventBus.RabbitMQ,
                EventNameSuffix = "IntegrationEvent",
                //Connection = new ConnectionFactory()
                //{
                //    HostName = "localhost",
                //    Port = 5672,
                //    UserName = "guest",
                //    Password = "guest",
                //}
            };
        }
    }
}