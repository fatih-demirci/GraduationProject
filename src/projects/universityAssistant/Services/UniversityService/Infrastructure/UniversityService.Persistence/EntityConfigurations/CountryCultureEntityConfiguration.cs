using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityService.Domain.Entities;

namespace UniversityService.Persistence.EntityConfigurations;

public class CountryCultureEntityConfiguration : IEntityTypeConfiguration<CountryCulture>
{
    public void Configure(EntityTypeBuilder<CountryCulture> builder)
    {
        builder.HasKey(cc => cc.Id);
        builder.HasOne(cc => cc.Country);
    }
}
