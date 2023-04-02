using EventBus.Base.Abstraction;
using NotificationService.Api.Extensions;
using NotificationService.Api.IntegrationEvents.EventHandlers;
using NotificationService.Api.IntegrationEvents.Events;
using NotificationService.Api.Mailing;
using NotificationService.Api.Mailing.MailDevelopment;
using NotificationService.Api.Mailing.MailKit;
using Core.CrossCuttingConcerns.Exceptions;

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

builder.Services.AddSingleton<IMailService>(i => env == "Development" ? new MailDevelopmentManager() : new MailKitManager(builder.Configuration));

builder.Services.AddEventBus(builder.Configuration);

builder.Services.AddTransient<SendEmailIntegrationEventHandler>();

var app = builder.Build();

app.ConfigureCustomExceptionMiddleware();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

await ConfigureEventBusForSubscription(app);

app.Run();

async Task ConfigureEventBusForSubscription(IApplicationBuilder app)
{
    var eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
    await eventBus.Subscribe<SendEmailIntegrationEvent, SendEmailIntegrationEventHandler>();
}