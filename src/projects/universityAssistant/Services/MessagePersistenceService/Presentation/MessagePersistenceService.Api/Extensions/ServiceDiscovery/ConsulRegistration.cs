using Consul;

namespace MessagePersistenceService.Api.Extensions.ServiceDiscovery;

public static class ConsulRegistration
{
    public static IServiceCollection ConfigureConsul(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IConsulClient>(p => new ConsulClient(consulConfig =>
        {
            var address = configuration["Consulconfig:Address"];
            consulConfig.Address = new Uri(address);
        }));

        return services;
    }

    public static IApplicationBuilder RegisterWithConsul(this IApplicationBuilder app, IConfiguration configuration)
    {
        var consulClient = app.ApplicationServices.GetRequiredService<IConsulClient>();
        var loggingFactory = app.ApplicationServices.GetRequiredService<ILoggerFactory>();
        var logger = loggingFactory.CreateLogger<IApplicationBuilder>();
        var lifetime = app.ApplicationServices.GetRequiredService<IHostApplicationLifetime>();
        AgentServiceRegistration registration = new();

        lifetime.ApplicationStarted.Register(async () =>
        {
            var uri = configuration.GetValue<Uri>("ConsulConfig:ServiceAddress");
            var serviceName = configuration.GetValue<string>("ConsulConfig:ServiceName");
            var serviceId = configuration.GetValue<string>("ConsulConfig:ServiceId");

            registration = new AgentServiceRegistration()
            {
                ID = serviceId ?? "MessagePersistence",
                Name = serviceName ?? "MessagePersistenceService",
                Address = uri.Host,
                Port = uri.Port,
                Tags = new[] { serviceName, serviceId }
            };

            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT")!;

            if (env != "Development")
            {
                registration.Checks = new AgentServiceCheck[]{new AgentCheckRegistration()
                {
                    HTTP = $"{uri.Scheme}://{uri.Host}:{uri.Port}{configuration.GetValue<string>("HealthCheck:ApiAddress")}",
                    Notes = $"Checks {uri.Scheme}://{uri.Host}:{uri.Port}{configuration.GetValue<string>("HealthCheck:ApiAddress")}",
                    Timeout = TimeSpan.FromSeconds(configuration.GetValue<int>("HealthCheck:Timeout")),
                    Interval = TimeSpan.FromSeconds(configuration.GetValue<int>("HealthCheck:Interval")),
                    Method = "GET",
                } };
            }

            logger.LogInformation("Registering with Consul");
            await consulClient.Agent.ServiceDeregister(registration.ID);
            await consulClient.Agent.ServiceRegister(registration);
        });

        lifetime.ApplicationStopped.Register(async () =>
        {
            logger.LogInformation("Deregistering from Consul");
            await consulClient.Agent.ServiceDeregister(registration.ID);
        });
        return app;
    }
}
