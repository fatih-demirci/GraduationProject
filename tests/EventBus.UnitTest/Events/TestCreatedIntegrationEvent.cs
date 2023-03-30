using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.UnitTest.Events
{
    public class TestCreatedIntegrationEvent : IntegrationEvent
    {
        public string Message { get; set; }
        public TestCreatedIntegrationEvent(string message)
        {
            Message = message;
        }
    }
}
