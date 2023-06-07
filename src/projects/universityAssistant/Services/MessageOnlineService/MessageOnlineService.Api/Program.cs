using Core.CrossCuttingConcerns.Exceptions;
using EventBus.Base.Abstraction;
using MessageOnlineService.Api.Extensions.Auth;
using MessageOnlineService.Api.Extensions.EventBus;
using MessageOnlineService.Api.Extensions.HealthCheck;
using MessageOnlineService.Api.Extensions.ServiceDiscovery;
using MessageOnlineService.Api.Hubs;
using MessageOnlineService.Api.IntegrationEvents.EventHandlers;
using MessageOnlineService.Api.IntegrationEvents.Events;
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
builder.Services.AddSignalR();
builder.Services.AddEventBus(builder.Configuration);
builder.Services.ConfigureConsul(builder.Configuration);
builder.Services.ConfigureAuth(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Services.AddHttpContextAccessor();

builder.Services.AddTransient<RemoveFromGroupIntegrationEventHandler>();
builder.Services.AddTransient<SendMessageIntegrationEventHandler>();
builder.Services.AddTransient<UserJoinedIntegrationEventHandler>();
builder.Services.AddTransient<UserLeavedIntegrationEventHandler>();

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

var app = builder.Build();

app.UseCustomHealtCheck(builder.Configuration);

app.ConfigureCustomExceptionMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapHub<MessageHub>("/message");

app.MapControllers();

app.RegisterWithConsul(builder.Configuration);

await ConfigureEventBusForSubscription(app);

app.Run();

async Task ConfigureEventBusForSubscription(IApplicationBuilder app)
{
    IEventBus eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    await eventBus.Subscribe<RemoveFromGroupIntegrationEvent, RemoveFromGroupIntegrationEventHandler>();
    await eventBus.Subscribe<SendMessageIntegrationEvent, SendMessageIntegrationEventHandler>();
    await eventBus.Subscribe<UserJoinedIntegrationEvent, UserJoinedIntegrationEventHandler>();
    await eventBus.Subscribe<UserLeavedIntegrationEvent, UserLeavedIntegrationEventHandler>();
}