﻿using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using UniversityService.Application.Services.Repositories;
using UniversityService.Persistence.Contexts;
using UniversityService.Persistence.Repositories;

namespace UniversityService.Persistence;

public static class PersistenceServiceRegistration
{
    public static IServiceCollection AddPersistenceService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<UniversityServiceContext>(options => options.UseSqlServer(configuration.GetConnectionString("UniversityConnectionString"), sqlServerOptionsAction: sqlOptions =>
        {
            //sqlOptions.EnableRetryOnFailure(maxRetryCount: 15, maxRetryDelay: TimeSpan.FromSeconds(30), errorNumbersToAdd: null);
        }));

        services.AddScoped<IUniversityDepartmentRepository, UniversityDepartmentRepository>();
        services.AddScoped<IUniversityRepository, UniversityRepository>();
        services.AddScoped<IProvienceRepository, ProvienceRepository>();
        services.AddScoped<ICountryRepository, CountryRepository>();
        services.AddScoped<IFacultyRepository, FacultyRepository>();
        services.AddScoped<IDepartmentRepository, DepartmentRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IUniversityCommentRepository, UniversityCommentRepository>();
        services.AddScoped<IUniversityCommentFileRepository, UniversityCommentFileRepository>();

        return services;
    }
}
