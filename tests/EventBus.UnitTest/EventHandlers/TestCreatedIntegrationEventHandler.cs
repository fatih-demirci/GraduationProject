using EventBus.Base.Abstraction;
using EventBus.UnitTest.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.UnitTest.EventHandlers
{
    public class TestCreatedIntegrationEventHandler : IIntegrationEventHandler<TestCreatedIntegrationEvent>
    {
        Task IIntegrationEventHandler<TestCreatedIntegrationEvent>.Handle(TestCreatedIntegrationEvent @event)
        {
            Console.WriteLine($"Handle method worked with Id :  {@event.IntegrationEventId} Message : {@event.Message}");
            return Task.CompletedTask;
        }
    }
}
