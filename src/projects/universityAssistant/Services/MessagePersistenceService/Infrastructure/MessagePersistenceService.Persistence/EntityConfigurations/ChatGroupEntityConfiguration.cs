using MessagePersistenceService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniversityService.Persistence.EntityConfigurations;

internal class ChatGroupEntityConfiguration : IEntityTypeConfiguration<ChatGroup>
{
    public void Configure(EntityTypeBuilder<ChatGroup> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasOne(c => c.User).WithMany(i => i.ChatGroups).OnDelete(DeleteBehavior.Restrict);
        builder.HasOne(c => c.ChatCategory);
        builder.HasMany(c => c.OnlineInChats);
        builder.HasMany(c => c.ChatGroupMessages);
    }
}