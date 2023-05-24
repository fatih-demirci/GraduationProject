using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using System.Text.RegularExpressions;
using UniversityService.Domain.Entities;

namespace UniversityService.Persistence.Contexts;

public class UniversityServiceContextSeed
{
    public async Task SeedAsync(UniversityServiceContext context, ILogger<UniversityServiceContextSeed> logger, IConfiguration configuration)
    {
        var policy = Policy.Handle<SqlException>().WaitAndRetryAsync(
            retryCount: 5,
            sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
            onRetry: (exception, timeSpan, retry, ctx) =>
            {
                logger.LogWarning(exception, $"{nameof(UniversityServiceContextSeed)} Exception {exception.GetType} with message {exception.Message}");
            }
            );

        await policy.ExecuteAsync(() => ProcessSeeding(context, logger, configuration));
    }

    private async Task ProcessSeeding(UniversityServiceContext context, ILogger<UniversityServiceContextSeed> logger, IConfiguration configuration)
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

        if (!context.Universities.Any())
        {
            context.Database.ExecuteSql($"SET IDENTITY_INSERT Universities ON");
            await context.Universities.AddRangeAsync(GetUniversitiesFromFile(contentRootPath, configuration));
            context.SaveChanges();
            context.Database.ExecuteSql($"SET IDENTITY_INSERT Universities OFF");
        }

        if (!context.UniversityDepartments.Any())
        {
            List<UniversityInfo> universityInfos = GetUniversityInfos(contentRootPath).ToList();

            foreach (var item in universityInfos)
            {
                University? university = context.Universities.SingleOrDefault(u => u.Name.ToUpper() == item.Name.ToUpper());
                university ??= context.Universities.Local.SingleOrDefault(u => u.Name.ToUpper() == item.Name.ToUpper());

                university ??= context.Universities.SingleOrDefault(u => u.Name.ToUpper().Contains(item.Name.ToUpper()));
                university ??= context.Universities.Local.SingleOrDefault(u => u.Name.ToUpper().Contains(item.Name.ToUpper()));

                if (university == null)
                {
                    Provience provience = context.Proviences.Single(p => item.City.ToLower().Contains(p.Name.ToLower()));
                    university = new()
                    {
                        Name = item.Name,
                        ProvienceId = provience.Id,
                        Status = true,
                        Type = item.UniversityType == "Devlet" ? (byte)0 : item.UniversityType == "Vakıf" ? (byte)1 : item.UniversityType == "KKTC" ? (byte)2 : (byte)3,
                    };
                    context.Universities.Add(university);
                }

                Department department;
                DepartmentCulture? departmentCulture = context.DepartmentCultures.SingleOrDefault(d => d.Name.ToLower() == item.DepartmentName.ToLower());
                departmentCulture ??= context.DepartmentCultures.Local.SingleOrDefault(d => d.Name.ToLower() == item.DepartmentName.ToLower());
                if (departmentCulture == null)
                {
                    departmentCulture = new DepartmentCulture()
                    {
                        Culture = "tr-TR",
                        Name = item.DepartmentName,
                    };
                    department = new()
                    {
                        DepartmentCultures = new List<DepartmentCulture>()
                        {
                            departmentCulture
                        }
                    };

                    context.Departments.Add(department);
                }

                Faculty faculty;
                FacultyCulture? facultyCulture = context.FacultyCultures.SingleOrDefault(fc => fc.Name.ToLower() == item.Faculty.ToLower());
                facultyCulture ??= context.FacultyCultures.Local.SingleOrDefault(fc => fc.Name.ToLower() == item.Faculty.ToLower());
                if (facultyCulture == null)
                {
                    facultyCulture = new FacultyCulture()
                    {
                        Culture = "tr-TR",
                        Name = item.Faculty
                    };

                    faculty = new() { FacultyCultures = new() { facultyCulture } };

                    context.Faculties.Add(faculty);
                }


                UniversityDepartment universityDepartment = new()
                {
                    Department = departmentCulture.Department,
                    Faculty = facultyCulture.Faculty,
                    University = university,
                    Language = item.Language,
                    YopCode = item.YopCode,
                    Price = item.Price,
                    EducationType = item.EducationType,
                    UniversityDepartmentInfos = new()
                };

                if (item.Quota2022 != null)
                {
                    universityDepartment.UniversityDepartmentInfos.Add(new UniversityDepartmentInfo()
                    {
                        MinimumPoint = item.MinimumPoint2022,
                        MinimumSuccessRank = item.MinimumSuccessRank2022,
                        Quota = item.Quota2022,
                        Settled = item.Settled2022,
                        Year = 2022
                    });
                }
                if (item.Quota2021 != null)
                {
                    universityDepartment.UniversityDepartmentInfos.Add(new UniversityDepartmentInfo()
                    {
                        MinimumPoint = item.MinimumPoint2021,
                        MinimumSuccessRank = item.MinimumSuccessRank2021,
                        Quota = item.Quota2021,
                        Settled = item.Settled2021,
                        Year = 2021
                    });
                }
                if (item.Quota2020 != null)
                {
                    universityDepartment.UniversityDepartmentInfos.Add(new UniversityDepartmentInfo()
                    {
                        MinimumPoint = item.MinimumPoint2020,
                        MinimumSuccessRank = item.MinimumSuccessRank2020,
                        Quota = item.Quota2020,
                        Settled = item.Settled2020,
                        Year = 2020
                    });
                }
                if (item.Quota2019 != null)
                {
                    universityDepartment.UniversityDepartmentInfos.Add(new UniversityDepartmentInfo()
                    {
                        MinimumPoint = item.MinimumPoint2019,
                        MinimumSuccessRank = item.MinimumSuccessRank2019,
                        Quota = item.Quota2019,
                        Settled = item.Settled2019,
                        Year = 2019
                    });
                }

                context.UniversityDepartments.Add(universityDepartment);
            }
        }

        context.SaveChanges();

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

    private IEnumerable<University> GetUniversitiesFromFile(string contentRootPath, IConfiguration configuration)
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
                LogoUrl = $"{configuration["StorageServiceImageUrlBase"]}{int.Parse(row[0])}.png",
                Status = true
            });
    }

    private IEnumerable<UniversityInfo> GetUniversityInfos(string contentRootPath)
    {
        List<string> files = new()
        {
          Path.Combine(contentRootPath, "say.csv"),
          Path.Combine(contentRootPath, "soz.csv"),
          Path.Combine(contentRootPath, "ea.csv"),
          Path.Combine(contentRootPath, "dil.csv")
        };

        List<UniversityInfo> universityInfos = new();

        foreach (string file in files)
        {
            if (!File.Exists(file))
            {
                break;
            }

            string[] rows = File.ReadAllLines(file);

            universityInfos.AddRange(
                    rows
                    .Skip(1)
                    .Select(row => Regex.Split(row, ",(?=(?:[^\"]*\"[^\"]*\")*[^\"]*$)"))
                    .Select(row => new UniversityInfo()
                    {
                        YopCode = row[0].Trim('"').Trim(),
                        Name = row[1].Trim('"').Trim(),
                        Faculty = row[2].Trim('"').Trim(),
                        DepartmentName = row[3].Trim('"').Trim(),
                        Language = row[4].Trim('"').Trim(),
                        City = row[5].Trim('"').Trim(),
                        UniversityType = row[6].Trim('"').Trim(),
                        Price = row[7].Trim('"').Trim(),
                        EducationType = row[8].Trim('"').Trim(),
                        Quota2022 = row[9].Trim('"').Trim().StartsWith("-") ? null : row[9].Trim('"').Trim(),
                        Quota2021 = row[10].Trim('"').Trim().StartsWith("-") ? null : row[10].Trim('"').Trim(),
                        Quota2020 = row[11].Trim('"').Trim().StartsWith("-") ? null : row[11].Trim('"').Trim(),
                        Quota2019 = row[12].Trim('"').Trim().StartsWith("-") ? null : row[12].Trim('"').Trim(),
                        Fullness = row[13].Trim('"').Trim(),
                        Settled2022 = row[14].Trim('"').Trim().StartsWith("-") ? "0" : row[14].Trim('"').Trim(),
                        Settled2021 = row[15].Trim('"').Trim().StartsWith("-") ? "0" : row[15].Trim('"').Trim(),
                        Settled2020 = row[16].Trim('"').Trim().StartsWith("-") ? "0" : row[16].Trim('"').Trim(),
                        Settled2019 = row[17].Trim('"').Trim().StartsWith("-") ? "0" : row[17].Trim('"').Trim(),
                        MinimumSuccessRank2022 = row[18].Trim('"').Trim() == "Dolmadı" ? "0" : row[18].Trim('"').Trim().StartsWith("-") ? null : row[18].Trim('"').Trim(),
                        MinimumSuccessRank2021 = row[19].Trim('"').Trim() == "Dolmadı" ? "0" : row[19].Trim('"').Trim().StartsWith("-") ? null : row[19].Trim('"').Trim(),
                        MinimumSuccessRank2020 = row[20].Trim('"').Trim() == "Dolmadı" ? "0" : row[20].Trim('"').Trim().StartsWith("-") ? null : row[20].Trim('"').Trim(),
                        MinimumSuccessRank2019 = row[21].Trim('"').Trim() == "Dolmadı" ? "0" : row[21].Trim('"').Trim().StartsWith("-") ? null : row[21].Trim('"').Trim(),
                        MinimumPoint2022 = row[22].Trim('"').Trim() == "Dolmadı" ? 0 : row[22].Trim('"').Trim().StartsWith("-") ? null : float.Parse(row[22].Trim('"').Trim()),
                        MinimumPoint2021 = row[23].Trim('"').Trim() == "Dolmadı" ? 0 : row[23].Trim('"').Trim().StartsWith("-") ? null : float.Parse(row[23].Trim('"').Trim()),
                        MinimumPoint2020 = row[24].Trim('"').Trim() == "Dolmadı" ? 0 : row[24].Trim('"').Trim().StartsWith("-") ? null : float.Parse(row[24].Trim('"').Trim()),
                        MinimumPoint2019 = row[25].Trim('"').Trim() == "Dolmadı" ? 0 : row[25].Trim('"').Trim().StartsWith("-") ? null : float.Parse(row[25].Trim('"').Trim())
                    }));

        }
        return universityInfos;
    }

    public class UniversityInfo
    {
        public string YopCode { get; set; }
        public string Name { get; set; }
        public string Faculty { get; set; }
        public string DepartmentName { get; set; }
        public string Language { get; set; }
        public string City { get; set; }
        public string UniversityType { get; set; }
        public string Price { get; set; }
        public string EducationType { get; set; }
        public string? Quota2022 { get; set; }
        public string? Quota2021 { get; set; }
        public string? Quota2020 { get; set; }
        public string? Quota2019 { get; set; }
        public string Fullness { get; set; }
        public string Settled2022 { get; set; }
        public string Settled2021 { get; set; }
        public string Settled2020 { get; set; }
        public string Settled2019 { get; set; }
        public string? MinimumSuccessRank2022 { get; set; }
        public string? MinimumSuccessRank2021 { get; set; }
        public string? MinimumSuccessRank2020 { get; set; }
        public string? MinimumSuccessRank2019 { get; set; }
        public float? MinimumPoint2022 { get; set; }
        public float? MinimumPoint2021 { get; set; }
        public float? MinimumPoint2020 { get; set; }
        public float? MinimumPoint2019 { get; set; }
    }
}
