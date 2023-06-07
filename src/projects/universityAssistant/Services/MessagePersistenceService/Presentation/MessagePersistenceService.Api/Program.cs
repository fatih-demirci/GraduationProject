using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Extensions;
using EventBus.Base.Abstraction;
using MessagePersistenceService.Api.Extensions.Auth;
using MessagePersistenceService.Api.Extensions.EventBus;
using MessagePersistenceService.Api.Extensions.HealthCheck;
using MessagePersistenceService.Api.Extensions.Localization;
using MessagePersistenceService.Api.Extensions.PublishExtensions;
using MessagePersistenceService.Api.Extensions.ServiceDiscovery;
using MessagePersistenceService.Api.Extensions.Swagger;
using MessagePersistenceService.Api.IntegrationEvents.EventHandlers;
using MessagePersistenceService.Api.IntegrationEvents.Events;
using MessagePersistenceService.Api.Middlewares;
using MessagePersistenceService.Application;
using MessagePersistenceService.Persistence;
using MessagePersistenceService.Persistence.Contexts;
using MessagePersistenceService.Infrastructure;
using Serilog;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());

builder.Configuration.AddJsonFile($"Configurations/appsettings.json", optional: false);
builder.Configuration.AddJsonFile($"Configurations/appsettings.{env}.json", optional: true);

builder.Configuration.AddJsonFile($"Configurations/serilog.json", optional: false);
builder.Configuration.AddJsonFile($"Configurations/serilog.{env}.json", optional: true);

builder.Configuration.AddEnvironmentVariables();

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.ConfigureSwagger();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddEventBus(builder.Configuration);
builder.Services.ConfigureConsul(builder.Configuration);
builder.Services.ConfigureAuth(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Services.AddPersistenceService(builder.Configuration);
builder.Services.AddApplicationService();
builder.Services.AddInfrastructureService(builder.Configuration);
builder.Services.AddHttpContextAccessor();
builder.Services.AddControllersWithViews().AddViewLocalization();
builder.Services.ConfigureLocalization();

builder.Services.AddScoped<RequestLocalizationCookiesMiddleware>();

builder.Services.AddTransient<AddToGroupIntegrationEventHandler>();
builder.Services.AddTransient<GetAllUsersIntegrationEventHandler>();
builder.Services.AddTransient<UserAddedIntegrationEventHandler>();
builder.Services.AddTransient<UserDisconnectedIntegrationEventHandler>();
builder.Services.AddTransient<UserUpdatedIntegrationEventHandler>();

var app = builder.Build();

app.UseCustomHealtCheck(app.Configuration);

app.UseRequestLocalization();

app.UseRequestLocalizationCookies();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.ConfigureCustomExceptionMiddleware();

await app.MigrateDbContext<MessagePersistenceServiceContext>(async (context, services) =>
{
    var logger = services.GetService<ILogger<MessagePersistenceServiceContextSeed>>();
    var dbContextSeeder = new MessagePersistenceServiceContextSeed();

    await dbContextSeeder.SeedAsync(context, logger, app.Configuration);
});

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.RegisterWithConsul(app.Configuration);

await ConfigureEventBusForSubscription(app);

app.Run();

async Task ConfigureEventBusForSubscription(IApplicationBuilder app)
{
    IEventBus eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    await eventBus.Subscribe<AddToGroupIntegrationEvent, AddToGroupIntegrationEventHandler>();
    await eventBus.Subscribe<GetAllUsersIntegrationEvent, GetAllUsersIntegrationEventHandler>();
    await eventBus.Subscribe<UserAddedIntegrationEvent, UserAddedIntegrationEventHandler>();
    await eventBus.Subscribe<UserDisconnectedIntegrationEvent, UserDisconnectedIntegrationEventHandler>();
    await eventBus.Subscribe<UserUpdatedIntegrationEvent, UserUpdatedIntegrationEventHandler>();
    await app.PublishApplicationStartedEvents();
}