using Core.Persistence.Repositories;

namespace UniversityService.Domain.Entities;

public class CountryCulture : Entity
{
    public long Id { get; set; }
    public long CountryId { get; set; }
    public string Name { get; set; }
    public string Culture { get; set; }
    public virtual Country Country { get; set; }
}

