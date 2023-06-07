using EventBus.Base.Events;

namespace MessagePersistenceService.Api.IntegrationEvents.Events;

public class UserLeavedIntegrationEvent : IntegrationEvent
{
    public UserLeavedIntegrationEvent(int chatGroupId, string connectionId)
    {
        ChatGroupId = chatGroupId;
        ConnectionId = connectionId;
    }

    public int ChatGroupId { get; set; }
    public string ConnectionId { get; set; }
}
