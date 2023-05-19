using EventBus.Base.Events;

namespace UniversityService.Api.IntegrationEvents.Events;

public class GetAllUsersIntegrationEvent : IntegrationEvent
{
    public List<GetAllUsersIntegrationEventUser> Users { get; set; }
}

public class GetAllUsersIntegrationEventUser
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string? ProfilePhotoUrl { get; set; }
    public bool Status { get; set; }
}