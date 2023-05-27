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

    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("Turkish_CI_AS");
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
    }

    public async Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
