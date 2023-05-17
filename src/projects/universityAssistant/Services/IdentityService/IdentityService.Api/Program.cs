using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Extensions;
using IdentityService.Api.Extensions.Auth;
using IdentityService.Api.Extensions.HealthCheck;
using IdentityService.Api.Extensions.ServiceDiscovery;
using IdentityService.Api.Extensions.Swagger;
using IdentityService.Application;
using IdentityService.Persistence;
using IdentityService.Persistence.Contexts;
using Serilog;
using IdentityService.Api.Extensions.EventBus;
using Core.CrossCuttingConcerns;
using IdentityService.Api.Extensions.Localization;
using IdentityService.Api.Middlewares;
using EventBus.Base.Abstraction;
using IdentityService.Api.IntegrationEvents.EventHandlers;
using IdentityService.Api.IntegrationEvents.Events;

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
builder.Services.ConfigureSwagger();

builder.Services.AddHttpContextAccessor();

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
    services.AddEventBus(configuration);
    services.AddCrossCuttingConcernServices();
    services.AddDistributedMemoryCache();
    services.AddControllersWithViews().AddViewLocalization();
    services.ConfigureLocalization();
    services.AddHttpContextAccessor();
    services.AddScoped<RequestLocalizationCookiesMiddleware>();
    services.AddTransient<GetAllUsersRequestIntegrationEventHandler>();
}

builder.Services.ConfigureAuth(builder.Configuration);

var app = builder.Build();

app.UseRequestLocalization();

app.UseRequestLocalizationCookies();

app.ConfigureCustomExceptionMiddleware();

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

await ConfigureEventBusForSubscription(app);

app.Run();

async Task ConfigureEventBusForSubscription(IApplicationBuilder app)
{
    IEventBus eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    await eventBus.Subscribe<GetAllUsersRequestIntegrationEvent, GetAllUsersRequestIntegrationEventHandler>();
}