using MessagePersistenceService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace UniversityService.Persistence.EntityConfigurations;

internal class ChatGroupMessageUrlEntityConfiguration : IEntityTypeConfiguration<ChatGroupMessageUrl>
{
    public void Configure(EntityTypeBuilder<ChatGroupMessageUrl> builder)
    {
        builder.HasKey(c => c.Id);
        builder.HasOne(c => c.ChatGroupMessage);

    }
}