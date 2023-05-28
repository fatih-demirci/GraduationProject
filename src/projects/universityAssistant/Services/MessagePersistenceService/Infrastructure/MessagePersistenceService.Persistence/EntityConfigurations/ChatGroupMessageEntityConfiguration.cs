using MessagePersistenceService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniversityService.Persistence.EntityConfigurations;

internal class ChatGroupMessageEntityConfiguration : IEntityTypeConfiguration<ChatGroupMessage>
{
    public void Configure(EntityTypeBuilder<ChatGroupMessage> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasOne(c => c.ChatGroup);
        builder.HasOne(c => c.User).WithMany(c => c.ChatGroupMessages).OnDelete(DeleteBehavior.Restrict);
        builder.HasMany(c => c.ChatGroupMessageUrls);
    }
}