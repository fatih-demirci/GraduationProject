using EventBus.Base.Abstraction;
using EventBus.Base;
using RabbitMQ.Client;
using EventBus.Factory;

namespace NotificationService.Api.Extensions
{
    public static class EventBusExtensions
    {
        public static IServiceCollection AddEventBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IEventBus>(sp =>
            {
                EventBusConfig config = new()
                {
                    ConnectionRetryCount = 5,
                    EventNameSuffix = "IntegrationEvent",
                    SubscriberClientAppName = "NotificationService",
                    EventBusType = EventBusConfig.EventBus.RabbitMQ,
                    Connection = new ConnectionFactory()
                    {
                        HostName = configuration["RabbitMQOptions:HostName"],
                        Password = configuration["RabbitMQOptions:Password"],
                        Port = int.Parse(configuration["RabbitMQOptions:Port"]!),
                        UserName = configuration["RabbitMQOptions:UserName"],
                    }
                };

                return EventBusFactory.Create(config, sp);
            });
            return services;
        }
    }
}
