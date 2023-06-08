namespace EventBus.Base
{
    public class EventBusConfig
    {
        public int ConnectionRetryCount { get; set; } = 5;
        public string DefaultTopicName { get; set; } = "UniversityAssistantEventBus";
        public string EventBusConnectionString { get; set; } = "";
        public string SubscriberClientAppName { get; set; } = "";
        public string EventNamePrefix { get; set; } = "";
        public string EventNameSuffix { get; set; } = "IntegrationEvent";
        public EventBus EventBusType { get; set; } = EventBus.RabbitMQ;
        public object? Connection { get; set; }

        public bool DeleteEventPrefix => !String.IsNullOrEmpty(EventNamePrefix);
        public bool DeleteEventSuffix => !String.IsNullOrEmpty(EventNameSuffix);

        public enum EventBus
        {
            RabbitMQ,
            AzureServiceBus
        }
    }
}
