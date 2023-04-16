using Microsoft.Data.SqlClient;
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
            string contentRootPath = "";

            if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
            {
                contentRootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
                contentRootPath = Path.Combine(contentRootPath, "Infrastructure", "UniversityService.Persistence", "Setup", "SeedFiles");
            }
            else
            {
                contentRootPath = "SeedFiles";
            }

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

    }
}
