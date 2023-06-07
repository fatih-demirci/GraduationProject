using EventBus.Base.Events;

namespace MessagePersistenceService.Api.IntegrationEvents.Events;

public class UserDisconnectedIntegrationEvent : IntegrationEvent
{
    public UserDisconnectedIntegrationEvent(string connectionId)
    {
        ConnectionId = connectionId;
    }

    public string ConnectionId { get; set; }
}
