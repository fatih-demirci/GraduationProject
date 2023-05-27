using EventBus.Base.Abstraction;
using MessagePersistenceService.Api.IntegrationEvents.Events;

namespace MessagePersistenceService.Api.Extensions.PublishExtensions;

public static class PublishEvents
{
    public static async Task PublishApplicationStartedEvents(this IApplicationBuilder app)
    {
        IEventBus eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
        await eventBus.Publish(new GetAllUsersRequestIntegrationEvent());
    }
}
