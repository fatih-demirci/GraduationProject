using Core.Persistence.Repositories;
using MessagePersistenceService.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using UniversityService.Persistence.EntityConfigurations;

namespace MessagePersistenceService.Persistence.Contexts;

public class MessagePersistenceServiceContext : DbContext, IUnitOfWork
{
    public MessagePersistenceServiceContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<ChatCategory> ChatCategories { get; set; }
    public DbSet<ChatGroup> ChatGroups { get; set; }
    public DbSet<ChatGroupMessage> ChatGroupMessages { get; set; }
    public DbSet<ChatGroupMessageUrl> ChatGroupMessageUrls { get; set; }
    public DbSet<OnlineInChat> OnlineInChats { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Turkish_CI_AS");
        modelBuilder.ApplyConfiguration(new ChatCategoryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ChatGroupEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ChatGroupMessageEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ChatGroupMessageUrlEntityConfiguration());
        modelBuilder.ApplyConfiguration(new OnlineInChatEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
    }

    public async Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
