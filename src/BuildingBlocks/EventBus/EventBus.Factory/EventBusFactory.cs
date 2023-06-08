﻿using EventBus.AzureServiceBus;
using EventBus.Base;
using EventBus.Base.Abstraction;
using EventBus.RabbitMQ;

namespace EventBus.Factory
{
    public static class EventBusFactory
    {
        public static IEventBus Create(EventBusConfig eventBusConfig, IServiceProvider serviceProvider)
        {
            return eventBusConfig.EventBusType switch
            {
                EventBusConfig.EventBus.AzureServiceBus => new EventBusServiceBus(serviceProvider, eventBusConfig),
                _ => new EventBusRabbitMQ(serviceProvider, eventBusConfig)
            };
        }
    }
}
