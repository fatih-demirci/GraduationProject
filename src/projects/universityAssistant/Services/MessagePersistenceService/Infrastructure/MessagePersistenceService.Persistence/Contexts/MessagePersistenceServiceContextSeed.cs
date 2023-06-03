using MessagePersistenceService.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Polly;
using System.Text.RegularExpressions;

namespace MessagePersistenceService.Persistence.Contexts;

public class MessagePersistenceServiceContextSeed
{
    public async Task SeedAsync(MessagePersistenceServiceContext context, ILogger<MessagePersistenceServiceContextSeed> logger, IConfiguration configuration)
    {
        var policy = Policy.Handle<SqlException>().WaitAndRetryAsync(
            retryCount: 5,
            sleepDurationProvider: retry => TimeSpan.FromSeconds(5),
            onRetry: (exception, timeSpan, retry, ctx) =>
            {
                logger.LogWarning(exception, $"{nameof(MessagePersistenceServiceContextSeed)} Exception {exception.GetType} with message {exception.Message}");
            }
            );

        await policy.ExecuteAsync(() => ProcessSeeding(context, logger, configuration));
    }

    private async Task ProcessSeeding(MessagePersistenceServiceContext context, ILogger<MessagePersistenceServiceContextSeed> logger, IConfiguration configuration)
    {
        string contentRootPath;

        if (Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") == "Development")
        {
            contentRootPath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;
            contentRootPath = Path.Combine(contentRootPath, "Infrastructure", "MessagePersistenceService.Persistence", "Setup", "SeedFiles");
        }
        else
        {
            contentRootPath = "SeedFiles";
        }

        await context.Database.OpenConnectionAsync();

        if (!context.ChatCategories.Any())
        {
            context.Database.ExecuteSql($"SET IDENTITY_INSERT ChatCategories ON");
            await context.ChatCategories.AddRangeAsync(GetChatCategoriesFromFile(contentRootPath));
            context.SaveChanges();
            context.Database.ExecuteSql($"SET IDENTITY_INSERT ChatCategories OFF");
        }

        await context.Database.CloseConnectionAsync();
    }

    private IEnumerable<ChatCategory> GetChatCategoriesFromFile(string contentRootPath)
    {
        string fileName = Path.Combine(contentRootPath, "ChatCategoriesSeedFile.txt");

        if (!File.Exists(fileName))
        {
            return new List<ChatCategory>();
        }

        return File.ReadAllLines(fileName)
            .Skip(1)
            .Select(row => Regex.Split(row, ","))
            .Select(row => new ChatCategory()
            {
                Id = int.Parse(row[0]),
                Name = row[1],
                ColorCode = row[2],
                Status = true
            });
    }
}
