using MessagePersistenceService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniversityService.Persistence.EntityConfigurations;

internal class ChatCategoryEntityConfiguration : IEntityTypeConfiguration<ChatCategory>
{
    public void Configure(EntityTypeBuilder<ChatCategory> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasMany(c => c.ChatGroups);
    }
}