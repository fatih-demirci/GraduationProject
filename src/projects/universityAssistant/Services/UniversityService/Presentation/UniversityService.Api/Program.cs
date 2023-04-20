using Core.Persistence.Extensions;
using UniversityService.Persistence;
using UniversityService.Persistence.Contexts;
using Core.CrossCuttingConcerns.Exceptions;
using UniversityService.Application;
using UniversityService.Api.Extensions.Localization;
using UniversityService.Api.Middlewares;

var builder = WebApplication.CreateBuilder(args);

string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());

builder.Configuration.AddJsonFile($"Configurations/appsettings.json", optional: false);
builder.Configuration.AddJsonFile($"Configurations/appsettings.{env}.json", optional: true);

builder.Configuration.AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllersWithViews().AddViewLocalization();
builder.Services.ConfigureLocalization();
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddApplicationService();

builder.Services.AddScoped<RequestLocalizationCookiesMiddleware>();

var app = builder.Build();

app.UseRequestLocalization();

app.UseRequestLocalizationCookies();

app.ConfigureCustomExceptionMiddleware();

await app.MigrateDbContext<UniversityServiceContext>(async (context, services) =>
{
    var logger = services.GetService<ILogger<UniversityServiceContextSeed>>();
    var dbContextSeeder = new UniversityServiceContextSeed();

    await dbContextSeeder.SeedAsync(context, logger);
});

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
