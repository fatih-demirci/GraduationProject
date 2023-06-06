using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using Ocelot.Provider.Consul;
using Serilog;
using Web.ApiGateway.Handlers;

var builder = WebApplication.CreateBuilder(args);

string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory());

builder.Configuration.AddJsonFile($"Configurations/appsettings.json", optional: false);
builder.Configuration.AddJsonFile($"Configurations/appsettings.{env}.json", optional: true);

builder.Configuration.AddJsonFile($"Configurations/ocelot.json", optional: false);
builder.Configuration.AddJsonFile($"Configurations/ocelot.{env}.json", optional: true);

builder.Configuration.AddJsonFile($"Configurations/serilog.json", optional: false);
builder.Configuration.AddJsonFile($"Configurations/serilog.{env}.json", optional: true);

builder.Configuration.AddEnvironmentVariables();

builder.Services.AddOcelot(builder.Configuration)
    .AddConsul().AddDelegatingHandler<UpdateProfilePhotoHandler>();

ConfigureHttpClient(builder.Services, builder.Configuration);
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog();

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
.CreateLogger();

builder.Services.AddTransient<HttpClientDelegatingHandler>();

void ConfigureHttpClient(IServiceCollection services, IConfiguration configuration)
{
    services.AddHttpContextAccessor();
    services.AddHttpClient("Files", c =>
    {
        c.BaseAddress = new Uri(configuration["Urls:Files"]!);
    }).AddHttpMessageHandler<HttpClientDelegatingHandler>();

    services.AddHttpClient("", c =>
    {
    }).AddHttpMessageHandler<HttpClientDelegatingHandler>();
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors(builder => builder.WithOrigins(app.Configuration["Cors:WebUI"]!).AllowAnyHeader().AllowAnyMethod().AllowCredentials().SetIsOriginAllowed(origin => true));

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.UseWebSockets();

await app.UseOcelot();

app.Run();
