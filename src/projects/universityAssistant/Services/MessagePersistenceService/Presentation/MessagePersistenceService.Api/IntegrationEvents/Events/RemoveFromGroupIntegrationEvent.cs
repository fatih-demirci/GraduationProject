using EventBus.Base.Events;

namespace MessagePersistenceService.Api.IntegrationEvents.Events;

public class RemoveFromGroupIntegrationEvent : IntegrationEvent
{
    public RemoveFromGroupIntegrationEvent(string connectionId, int chatGroupId)
    {
        ConnectionId = connectionId;
        ChatGroupId = chatGroupId;
    }

    public string ConnectionId { get; set; }
    public int ChatGroupId { get; set; }
}
