using EventBus.Base.Events;

namespace UniversityService.Api.IntegrationEvents.Events;

public class UserUpdatedIntegrationEvent : IntegrationEvent
{
    public List<UserUpdatedIntegrationEventUser> Users { get; set; }
}

public class UserUpdatedIntegrationEventUser
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string? ProfilePhotoUrl { get; set; }
    public bool Status { get; set; }
}