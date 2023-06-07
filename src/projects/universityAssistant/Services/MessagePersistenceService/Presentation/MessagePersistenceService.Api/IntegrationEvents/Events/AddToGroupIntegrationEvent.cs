using EventBus.Base.Events;

namespace MessagePersistenceService.Api.IntegrationEvents.Events;

public class AddToGroupIntegrationEvent : IntegrationEvent
{
    public int ChatGroupId { get; set; }
    public long UserId { get; set; }
    public string ConnectionId { get; set; }
}
