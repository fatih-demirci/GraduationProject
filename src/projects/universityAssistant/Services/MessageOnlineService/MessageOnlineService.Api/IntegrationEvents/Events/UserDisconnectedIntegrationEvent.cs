using EventBus.Base.Events;

namespace MessageOnlineService.Api.IntegrationEvents.Events;

public class UserDisconnectedIntegrationEvent : IntegrationEvent
{
    public UserDisconnectedIntegrationEvent(string connectionId)
    {
        ConnectionId = connectionId;
    }

    public string ConnectionId { get; set; }
}
