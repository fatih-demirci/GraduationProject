﻿using Core.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using UniversityService.Domain.Entities;
using UniversityService.Persistence.EntityConfigurations;

namespace UniversityService.Persistence.Contexts;

public class UniversityServiceContext : DbContext, IUnitOfWork
{
    public UniversityServiceContext(DbContextOptions options) : base(options)
    {

    }

    public DbSet<Country> Countries { get; set; }
    public DbSet<CountryCulture> CountryCultures { get; set; }
    public DbSet<Provience> Proviences { get; set; }
    public DbSet<Faculty> Faculties { get; set; }
    public DbSet<FacultyCulture> FacultyCultures { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<DepartmentCulture> DepartmentCultures { get; set; }
    public DbSet<University> Universities { get; set; }
    public DbSet<UniversityDepartment> UniversityDepartments { get; set; }
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new CountryEntityConfiguration());
        modelBuilder.ApplyConfiguration(new CountryCultureEntityConfiguration());
        modelBuilder.ApplyConfiguration(new ProvienceEntityConfiguration());
        modelBuilder.ApplyConfiguration(new FacultyEntityConfiguration());
        modelBuilder.ApplyConfiguration(new FacultyCultureEntityConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new DepartmentCultureEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UniversityEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UniversityDepartmentEntityConfiguration());
        modelBuilder.ApplyConfiguration(new UserEntityConfiguration());
    }

    public async Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default)
    {
        return await base.SaveChangesAsync(cancellationToken);
    }
}
