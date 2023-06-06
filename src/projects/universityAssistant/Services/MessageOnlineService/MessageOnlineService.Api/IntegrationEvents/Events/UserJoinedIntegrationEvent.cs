using EventBus.Base.Events;

namespace MessageOnlineService.Api.IntegrationEvents.Events;

public class UserJoinedIntegrationEvent : IntegrationEvent
{
    public string ConnectionId { get; set; }
    public long UserId { get; set; }
    public int ChatGroupId { get; set; }
    public string UserName { get; set; }
    public string ProfilePhotoUrl { get; set; }
}
