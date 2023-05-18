﻿using Core.Persistence.Repositories;

namespace UniversityService.Domain.Entities;

public class User : Entity
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string? ProfilePhotoUrl { get; set; }
    public bool Status { get; set; }
}
