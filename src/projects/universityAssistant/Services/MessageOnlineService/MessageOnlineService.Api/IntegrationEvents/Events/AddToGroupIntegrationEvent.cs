using EventBus.Base.Events;

namespace MessageOnlineService.Api.IntegrationEvents.Events;

public class AddToGroupIntegrationEvent : IntegrationEvent
{
    public AddToGroupIntegrationEvent(int chatGroupId, long userId, string connectionId)
    {
        ChatGroupId = chatGroupId;
        UserId = userId;
        ConnectionId = connectionId;
    }

    public int ChatGroupId { get; set; }
    public long UserId { get; set; }
    public string ConnectionId { get; set; }
}
