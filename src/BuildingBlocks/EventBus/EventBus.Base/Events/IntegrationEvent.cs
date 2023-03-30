using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EventBus.Base.Events
{
    public class IntegrationEvent
    {
        public IntegrationEvent(Guid integrationEventId, DateTime createdDate)
        {
            IntegrationEventId = integrationEventId;
            CreatedDate = createdDate;
        }

        [JsonConstructor]
        public IntegrationEvent()
        {
            IntegrationEventId = Guid.NewGuid();
            CreatedDate = DateTime.Now;
        }

        [JsonProperty]
        public Guid IntegrationEventId { get; set; }

        [JsonProperty]
        public DateTime CreatedDate { get; set; }
    }
}
