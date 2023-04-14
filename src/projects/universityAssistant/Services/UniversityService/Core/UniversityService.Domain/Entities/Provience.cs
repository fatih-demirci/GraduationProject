using Core.Persistence.Repositories;

namespace UniversityService.Domain.Entities;

public class Provience : Entity
{
    public long Id { get; set; }
    public long CountryId { get; set; }
    public string Name { get; set; }
    public virtual Country Country { get; set; }
}
