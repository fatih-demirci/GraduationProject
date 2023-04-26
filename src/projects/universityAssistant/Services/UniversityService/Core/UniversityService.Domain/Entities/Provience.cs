using Core.Persistence.Repositories;

namespace UniversityService.Domain.Entities;

public class Provience : Entity
{
    public int Id { get; set; }
    public int CountryId { get; set; }
    public string Name { get; set; }
    public virtual Country Country { get; set; }
    public virtual List<University> Universities { get; set; }
}
