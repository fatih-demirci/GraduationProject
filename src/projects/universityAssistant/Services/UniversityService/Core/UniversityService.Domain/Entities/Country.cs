using Core.Persistence.Repositories;

namespace UniversityService.Domain.Entities;

public class Country : Entity
{
    public Country()
    {
        CountryCultures = new();
        Proviences = new();
    }

    public long Id { get; set; }
    public virtual List<CountryCulture> CountryCultures { get; set; }
    public virtual List<Provience> Proviences { get; set; }
}

