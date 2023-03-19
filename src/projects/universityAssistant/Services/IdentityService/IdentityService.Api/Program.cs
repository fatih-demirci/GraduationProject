using IdentityService.Api.Extensions.HealthCheck;
using IdentityService.Api.Extensions.ServiceDiscovery;

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
ConfigureServices(builder.Services, builder.Configuration);

void ConfigureServices(IServiceCollection services, IConfiguration configuration)
{
    services.ConfigureConsul(configuration);
    services.AddHealthChecks();
}

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

app.RegisterWithConsul(app.Configuration);

app.Run();
