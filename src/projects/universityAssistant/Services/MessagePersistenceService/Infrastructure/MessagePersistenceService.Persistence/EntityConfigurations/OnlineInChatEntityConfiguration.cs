using MessagePersistenceService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniversityService.Persistence.EntityConfigurations;

internal class OnlineInChatEntityConfiguration : IEntityTypeConfiguration<OnlineInChat>
{
    public void Configure(EntityTypeBuilder<OnlineInChat> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasOne(c => c.ChatGroup);
        builder.HasOne(c => c.User).WithMany(i => i.OnlineInChats).OnDelete(DeleteBehavior.Restrict);
    }
}