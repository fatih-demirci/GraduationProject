using StorageService.Api.Extensions.HealthCheck;
using StorageService.Api.Extensions.ServiceDiscovery;
using StorageService.Api.Storage;
using StorageService.Api.Storage.Server;

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
builder.Services.ConfigureConsul(builder.Configuration);
builder.Services.AddHealthChecks();

builder.Services.AddScoped<IStorage, StorageServerManager>();
builder.Services.AddScoped<IStorageService, StorageManager>();
builder.Services.AddScoped<IFileService, FileManager>();

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

app.Run();
