﻿using EventBus.Base.Events;

namespace EventBus.Base.Abstraction
{
    public interface IEventBus
    {
        Task Publish(IntegrationEvent @event);
        Task Subscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
        Task UnSubscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
    }
}
