using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Base.Abstraction
{
    public interface IEventBus
    {
        Task Publish(IntegrationEvent @event);
        Task Subscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
        Task UnSubscribe<T, TH>() where T : IntegrationEvent where TH : IIntegrationEventHandler<T>;
    }
}
