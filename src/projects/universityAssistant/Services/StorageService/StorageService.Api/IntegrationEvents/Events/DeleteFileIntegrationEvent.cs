using EventBus.Base.Events;

namespace StorageService.Api.IntegrationEvents.Events
{
    public class DeleteFileIntegrationEvent : IntegrationEvent
    {
        public string FileNameForStorage { get; set; }
    }
}
