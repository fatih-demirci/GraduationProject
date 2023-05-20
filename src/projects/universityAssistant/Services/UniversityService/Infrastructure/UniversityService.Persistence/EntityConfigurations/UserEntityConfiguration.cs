using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityService.Domain.Entities;

namespace UniversityService.Persistence.EntityConfigurations;

internal class UserEntityConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.Property(c => c.Id).ValueGeneratedNever();
        builder.HasKey(c => c.Id);
        builder.HasMany(c => c.UniversityComments);
    }
}
