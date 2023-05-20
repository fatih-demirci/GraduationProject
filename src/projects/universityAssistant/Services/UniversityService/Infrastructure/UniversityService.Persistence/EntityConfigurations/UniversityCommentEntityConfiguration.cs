using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityService.Domain.Entities;

namespace UniversityService.Persistence.EntityConfigurations;

internal class UniversityCommentEntityConfiguration : IEntityTypeConfiguration<UniversityComment>
{
    public void Configure(EntityTypeBuilder<UniversityComment> builder)
    {
        builder.HasKey(uc => uc.Id);
        builder.HasOne(uc => uc.User);
        builder.HasOne(uc => uc.University);
        builder.HasMany(uc => uc.UniversityCommentFiles);
    }
}