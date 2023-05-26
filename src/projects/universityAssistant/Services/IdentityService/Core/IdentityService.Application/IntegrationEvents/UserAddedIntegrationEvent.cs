﻿using EventBus.Base.Events;

namespace IdentityService.Application.IntegrationEvents;

public class UserAddedIntegrationEvent : IntegrationEvent
{
    public List<UserAddedIntegrationEventUser> Users { get; set; }
}

public class UserAddedIntegrationEventUser
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string? ProfilePhotoUrl { get; set; }
    public bool Status { get; set; }
}