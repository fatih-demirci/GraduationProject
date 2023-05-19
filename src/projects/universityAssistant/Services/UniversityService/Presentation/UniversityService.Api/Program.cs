using Core.Persistence.Extensions;
using UniversityService.Persistence;
using UniversityService.Persistence.Contexts;
using Core.CrossCuttingConcerns.Exceptions;
using UniversityService.Application;
using UniversityService.Api.Extensions.Localization;
using UniversityService.Api.Middlewares;
using UniversityService.Api.Extensions.Controllers;
using UniversityService.Api.Extensions.ServiceDiscovery;
using UniversityService.Api.Extensions.HealthCheck;
using Serilog;
using UniversityService.Api.Extensions.Swagger;
using UniversityService.Api.Extensions.Auth;
using EventBus.Base.Abstraction;
using UniversityService.Api.IntegrationEvents.Events;
using UniversityService.Api.IntegrationEvents.EventHandlers;
using UniversityService.Api.Extensions.PublishExtensions;
using UniversityService.Api.Extensions.EventBus;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());

builder.Configuration.AddJsonFile($"Configurations/appsettings.json", optional: false);
builder.Configuration.AddJsonFile($"Configurations/appsettings.{env}.json", optional: true);

builder.Configuration.AddJsonFile($"Configurations/serilog.json", optional: false);
builder.Configuration.AddJsonFile($"Configurations/serilog.{env}.json", optional: true);

builder.Configuration.AddEnvironmentVariables();

// Add services to the container.

builder.Services.ConfigureControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();
builder.Services.AddControllersWithViews().AddViewLocalization();
builder.Services.ConfigureLocalization();
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.ConfigureConsul(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Services.AddHttpContextAccessor();
builder.Services.ConfigureAuth(builder.Configuration);
builder.Services.AddEventBus(builder.Configuration);
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.AddTransient<GetAllUsersIntegrationEventHandler>();
builder.Services.AddScoped<RequestLocalizationCookiesMiddleware>();

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

var app = builder.Build();

app.UseCustomHealtCheck(app.Configuration);

app.UseRequestLocalization();

app.UseRequestLocalizationCookies();

app.ConfigureCustomExceptionMiddleware();

await app.MigrateDbContext<UniversityServiceContext>(async (context, services) =>
{
    var logger = services.GetService<ILogger<UniversityServiceContextSeed>>();
    var dbContextSeeder = new UniversityServiceContextSeed();

    await dbContextSeeder.SeedAsync(context, logger, app.Configuration);
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

app.RegisterWithConsul(app.Configuration);

await ConfigureEventBusForSubscription(app);

app.Run();

async Task ConfigureEventBusForSubscription(IApplicationBuilder app)
{
    IEventBus eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    await eventBus.Subscribe<GetAllUsersIntegrationEvent, GetAllUsersIntegrationEventHandler>();
    await app.PublishApplicationStartedEvents();
}
