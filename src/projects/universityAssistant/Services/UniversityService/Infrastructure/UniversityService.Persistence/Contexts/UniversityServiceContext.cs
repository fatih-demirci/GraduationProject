using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Domain.Entities;
using UniversityService.Persistence.EntityConfigurations;

namespace UniversityService.Persistence.Contexts
{
    public class UniversityServiceContext : DbContext, IUnitOfWork
    {
        public UniversityServiceContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<CountryCulture> CountryCultures { get; set; }
        public DbSet<Provience> Proviences { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new CountryEntityConfiguration());
            modelBuilder.ApplyConfiguration(new CountryCultureEntityConfiguration());
            modelBuilder.ApplyConfiguration(new ProvienceEntityConfiguration());
        }

        public async Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
