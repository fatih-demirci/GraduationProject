using EventBus.Base.Events;

namespace MessageOnlineService.Api.IntegrationEvents.Events;

public class UserLeavedIntegrationEvent : IntegrationEvent
{
    public int ChatGroupId { get; set; }
    public string ConnectionId { get; set; }
}
