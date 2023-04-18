using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Polly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using UniversityService.Domain.Entities;

namespace UniversityService.Persistence.Contexts
{
    public class UniversityServiceContextSeed
    {
        public async Task SeedAsync(UniversityServiceContext context, ILogger<UniversityServiceContextSeed> logger)
        {
            var policy = Policy.Handle<SqlException>().WaitAndRetryAsync(
                retryCount: 5,
                sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
                onRetry: (exception, timeSpan, retry, ctx) =>
                {
                    logger.LogWarning(exception, $"{nameof(UniversityServiceContextSeed)} Exception {exception.GetType} with message {exception.Message}");
                }
                );

            await policy.ExecuteAsync(() => ProcessSeeding(context, logger));
        }

        private async Task ProcessSeeding(UniversityServiceContext context, ILogger<UniversityServiceContextSeed> logger)
        {
            string contentRootPath;

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                contentRootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                contentRootPath = Path.Combine(contentRootPath, "Infrastructure", "UniversityService.Persistence", "Setup", "SeedFiles");
            }
            else
            {
                contentRootPath = "SeedFiles";
            }

            await context.Database.OpenConnectionAsync();

            if (!context.Countries.Any())
            {
                await context.Countries.AddRangeAsync(GetCountriesFromFile(contentRootPath));
                context.SaveChanges();
            }

            if (!context.CountryCultures.Any())
            {
                await context.CountryCultures.AddRangeAsync(GetCountryCulturesFromFile(contentRootPath));
                context.SaveChanges();
            }

            if (!context.Proviences.Any())
            {
                await context.Proviences.AddRangeAsync(GetProviencesFromFile(contentRootPath));
                context.SaveChanges();
            }

            if (!context.Faculties.Any())
            {
                context.Database.ExecuteSql($"SET IDENTITY_INSERT Faculties ON");
                await context.Faculties.AddRangeAsync(GetFacultiesFromFile(contentRootPath));
                context.SaveChanges();
                context.Database.ExecuteSql($"SET IDENTITY_INSERT Faculties OFF");
            }

            if (!context.FacultyCultures.Any())
            {
                await context.FacultyCultures.AddRangeAsync(GetFacultyCulturesFromFile(contentRootPath));
                context.SaveChanges();
            }

            if (!context.Departments.Any())
            {
                context.Database.ExecuteSql($"SET IDENTITY_INSERT Departments ON");
                await context.Departments.AddRangeAsync(GetDepartmentsFromFile(contentRootPath));
                context.SaveChanges();
                context.Database.ExecuteSql($"SET IDENTITY_INSERT Departments OFF");
            }

            if (!context.DepartmentCultures.Any())
            {
                await context.DepartmentCultures.AddRangeAsync(GetDepartmentCulturesFromFile(contentRootPath));
                context.SaveChanges();
            }

            if (!context.Universities.Any())
            {
                context.Database.ExecuteSql($"SET IDENTITY_INSERT Universities ON");
                await context.Universities.AddRangeAsync(GetUniversitiesFromFile(contentRootPath));
                context.SaveChanges();
                context.Database.ExecuteSql($"SET IDENTITY_INSERT Universities OFF");
            }

            if (!context.UniversityDepartments.Any())
            {
                await context.UniversityDepartments.AddRangeAsync(GetUniversityDepartments(contentRootPath));
                context.SaveChanges();
            }

            await context.Database.CloseConnectionAsync();
        }

        private IEnumerable<Country> GetCountriesFromFile(string contentRootPath)
        {
            string fileName = Path.Combine(contentRootPath, "CountriesSeedFile.txt");

            if (!File.Exists(fileName))
            {
                return new List<Country>();
            }

            return File.ReadAllLines(fileName)
                .Skip(1)
                .Select(row => Regex.Split(row, ","))
                .Select(row => new Country()
                {
                    Id = int.Parse(row[0])
                });
        }

        private IEnumerable<CountryCulture> GetCountryCulturesFromFile(string contentRootPath)
        {
            string fileName = Path.Combine(contentRootPath, "CountryCulturesSeedFile.txt");

            if (!File.Exists(fileName))
            {
                return new List<CountryCulture>();
            }

            return File.ReadAllLines(fileName)
                .Skip(1)
                .Select(row => Regex.Split(row, ","))
                .Select(row => new CountryCulture()
                {
                    CountryId = int.Parse(row[0]),
                    Name = row[1],
                    Culture = row[2]
                });
        }

        private IEnumerable<Provience> GetProviencesFromFile(string contentRootPath)
        {
            string fileName = Path.Combine(contentRootPath, "ProviencesSeedFile.csv");

            if (!File.Exists(fileName))
            {
                return new List<Provience>();
            }

            return File.ReadAllLines(fileName)
                .Skip(1)
                .Select(row => Regex.Split(row, ","))
                .Select(row => new Provience()
                {
                    Id = int.Parse(row[0]),
                    CountryId = int.Parse(row[1]),
                    Name = row[2]
                });
        }

        private IEnumerable<Faculty> GetFacultiesFromFile(string contentRootPath)
        {
            string fileName = Path.Combine(contentRootPath, "FacultiesSeedFile.txt");

            if (!File.Exists(fileName))
            {
                return new List<Faculty>();
            }

            return File.ReadAllLines(fileName)
                .Skip(1)
                .Select(row => Regex.Split(row, ","))
                .Select(row => new Faculty()
                {
                    Id = int.Parse(row[0]),
                });
        }

        private IEnumerable<FacultyCulture> GetFacultyCulturesFromFile(string contentRootPath)
        {
            string fileName = Path.Combine(contentRootPath, "FacultyCulturesSeedFile.csv");

            if (!File.Exists(fileName))
            {
                return new List<FacultyCulture>();
            }

            return File.ReadAllLines(fileName)
                .Skip(1)
                .Select(row => Regex.Split(row, ","))
                .Select(row => new FacultyCulture()
                {
                    Culture = row[1],
                    Name = row[2],
                    FacultyId = int.Parse(row[3]),
                });
        }

        private IEnumerable<Department> GetDepartmentsFromFile(string contentRootPath)
        {
            string fileName = Path.Combine(contentRootPath, "DepartmentsSeedFile.txt");

            if (!File.Exists(fileName))
            {
                return new List<Department>();
            }

            return File.ReadAllLines(fileName)
                .Skip(1)
                .Select(row => Regex.Split(row, ","))
                .Select(row => new Department()
                {
                    Id = int.Parse(row[0]),
                });
        }

        private IEnumerable<DepartmentCulture> GetDepartmentCulturesFromFile(string contentRootPath)
        {
            string fileName = Path.Combine(contentRootPath, "DepartmentCulturesSeedFile.csv");

            if (!File.Exists(fileName))
            {
                return new List<DepartmentCulture>();
            }

            return File.ReadAllLines(fileName)
                .Skip(1)
                .Select(row => Regex.Split(row, ","))
                .Select(row => new DepartmentCulture()
                {
                    Culture = row[1],
                    Name = row[2],
                    DepartmentId = int.Parse(row[3]),
                });
        }

        private IEnumerable<University> GetUniversitiesFromFile(string contentRootPath)
        {
            string csvFileName = Path.Combine(contentRootPath, "UniversitiesSeedFile.csv");

            if (!File.Exists(csvFileName))
            {
                return new List<University>();
            }

            return File.ReadAllLines(csvFileName)
                .Skip(1)
                .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                .Select(row => new University()
                {
                    Id = int.Parse(row[0]),
                    Name = row[1].Trim('"').Trim(),
                    Website = row[2].Trim('"').Trim(),
                    Email = row[3].Trim('"').Trim(),
                    Phone = row[4].Trim('"').Trim(),
                    Fax = row[5].Trim('"').Trim(),
                    Address = row[6].Trim('"').Trim(),
                    Type = byte.Parse(row[7].Trim('"').Trim()),
                    ProvienceId = int.Parse(row[8]),
                    Status = true
                });
        }

        private IEnumerable<UniversityDepartment> GetUniversityDepartments(string contentRootPath)
        {
            string fileName = Path.Combine(contentRootPath, "UniversityDepartmentSeedFile.txt");

            if (!File.Exists(fileName))
            {
                return new List<UniversityDepartment>();
            }

            return File.ReadAllLines(fileName)
                .Skip(1)
                .Select(row => Regex.Split(row, ","))
                .Select(row => new UniversityDepartment()
                {
                    UniversityId = int.Parse(row[0]),
                    FacultyId = int.Parse(row[1]),
                    DepartmentId = int.Parse(row[2])
                });
        }
    }
}
