using EventBus.Base.Events;

namespace IdentityService.Application.IntegrationEvents
{
    public class DeleteFileIntegrationEvent : IntegrationEvent
    {
        public DeleteFileIntegrationEvent(string fileNameForStorage)
        {
            FileNameForStorage = fileNameForStorage;
        }

        public string FileNameForStorage { get; set; }
    }
}
