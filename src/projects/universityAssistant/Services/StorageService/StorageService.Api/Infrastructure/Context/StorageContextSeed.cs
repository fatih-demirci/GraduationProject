using Polly;
using StorageService.Api.Storage;
using System.IO.Compression;

namespace StorageService.Api.Infrastructure.Context;

public class StorageContextSeed
{
    public async Task SeedAsync(ILogger<StorageContextSeed> logger)
    {
        var policy = Policy.Handle<Exception>().WaitAndRetryAsync(
            retryCount: 5,
            sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
            onRetry: (exception, timeSpan, retry, ctx) =>
            {
                logger.LogWarning(exception, $"{nameof(StorageContextSeed)} Exception {exception.GetType} with message {exception.Message}");
            }
            );

        await policy.ExecuteAsync(() => ProcessSeeding(logger));
    }

    private async Task ProcessSeeding(ILogger<StorageContextSeed> logger)
    {
        string contentRootPath;

        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            contentRootPath = Directory.GetParent(Directory.GetCurrentDirectory()).FullName;
            contentRootPath = Path.Combine(contentRootPath, "StorageService.Api", "Infrastructure", "Setup", "SeedFiles");
        }
        else
        {
            contentRootPath = "SeedFiles";
        }

        GetUniversityLogos(contentRootPath);
    }

    private void GetUniversityLogos(string contentPath)
    {
        string picturePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", FileType.Image.ToString());

        string zipFileUniversityLogos = Path.Combine(contentPath, "UniversityLogos.zip");
        if (!File.Exists(zipFileUniversityLogos) || File.Exists(Path.Combine(picturePath, "1.png")))
            return;

        ZipFile.ExtractToDirectory(zipFileUniversityLogos, picturePath);

        //FileInfo zipInfo = new(zipFileUniversityLogos);
        //zipInfo.Delete();
    }
}
