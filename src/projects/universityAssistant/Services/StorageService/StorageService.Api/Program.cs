using EventBus.Base.Abstraction;
using Serilog;
using StorageService.Api.Extensions.EventBus;
using StorageService.Api.Extensions.HealthCheck;
using StorageService.Api.Extensions.ServiceDiscovery;
using StorageService.Api.IntegrationEvents.EventHandlers;
using StorageService.Api.IntegrationEvents.Events;
using StorageService.Api.Storage;
using StorageService.Api.Storage.Server;

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
builder.Services.ConfigureConsul(builder.Configuration);
builder.Services.AddHealthChecks();
builder.Services.AddEventBus(builder.Configuration);

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();

builder.Services.AddScoped<IStorage, StorageServerManager>();
builder.Services.AddScoped<IStorageService, StorageManager>();
builder.Services.AddScoped<IFileService, FileManager>();
builder.Services.AddTransient<DeleteFileIntegrationEventHandler>();

var app = builder.Build();

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

app.RegisterWithConsul(builder.Configuration);

await ConfigureEventBusForSubscription(app);

app.Run();

async Task ConfigureEventBusForSubscription(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    await eventBus.Subscribe<DeleteFileIntegrationEvent, DeleteFileIntegrationEventHandler>();
}