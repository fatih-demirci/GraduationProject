using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityService.Domain.Entities;

namespace UniversityService.Persistence.EntityConfigurations;

public class CountryEntityConfiguration : IEntityTypeConfiguration<Country>
{
    public void Configure(EntityTypeBuilder<Country> builder)
    {
        builder.Property(c => c.Id).ValueGeneratedNever();
        builder.HasKey(c => c.Id);
        builder.HasMany(c => c.CountryCultures);
        builder.HasMany(c => c.Proviences);
    }
}
