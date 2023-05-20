using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UniversityService.Domain.Entities;

namespace UniversityService.Persistence.EntityConfigurations;

internal class UniversityCommentFileEntityConfiguration : IEntityTypeConfiguration<UniversityCommentFile>
{
    public void Configure(EntityTypeBuilder<UniversityCommentFile> builder)
    {
        builder.HasKey(uc => uc.Id);
        builder.HasOne(uc => uc.UniversityComment);
    }
}
