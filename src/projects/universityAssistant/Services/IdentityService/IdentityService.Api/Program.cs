using Core.Persistence.Extensions;
using IdentityService.Api.Extensions.Auth;
using IdentityService.Api.Extensions.HealthCheck;
using IdentityService.Api.Extensions.ServiceDiscovery;
using IdentityService.Application;
using IdentityService.Persistence;
using IdentityService.Persistence.Contexts;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());

builder.Configuration.AddJsonFile($"Configurations/appsettings.json", optional: false);
builder.Configuration.AddJsonFile($"Configurations/appsettings.{env}.json", optional: true);

builder.Configuration.AddJsonFile($"Configurations/serilog.json", optional: false);
builder.Configuration.AddJsonFile($"Configurations/serilog.{env}.json", optional: true);

builder.Configuration.AddEnvironmentVariables();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
ConfigureServices(builder.Services, builder.Configuration);

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.ConfigureConsul(configuration);
    services.AddHealthChecks();
    services.AddPersistenceService(configuration);
    services.AddApplicationService();
}

builder.Services.ConfigureAuth(builder.Configuration);

var app = builder.Build();

await app.MigrateDbContext<IdentityServiceContext>(async (context, services) =>
{
    var logger = services.GetService<ILogger<IdentityServiceContextSeed>>();
    var dbContextSeeder = new IdentityServiceContextSeed();

    await dbContextSeeder.SeedAsync(context, logger);
});

app.UseCustomHealtCheck(app.Configuration);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.RegisterWithConsul(app.Configuration);

app.Run();
