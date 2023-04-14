using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityService.Domain.Entities;

namespace UniversityService.Persistence.EntityConfigurations;

public class ProvienceEntityConfiguration : IEntityTypeConfiguration<Provience>
{
    public void Configure(EntityTypeBuilder<Provience> builder)
    {
        builder.Property(x => x.Id).ValueGeneratedNever();
        builder.HasKey(x => x.Id);
        builder.HasOne(p => p.Country);
    }
}
