using EventBus.Base.Abstraction;
using UniversityService.Api.IntegrationEvents.Events;

namespace UniversityService.Api.Extensions.PublishExtensions;

public static class PublishEvents
{
    public static async Task PublishApplicationStartedEvents(this IApplicationBuilder app)
    {
        IEventBus eventBus = app.ApplicationServices.GetRequiredService<IEventBus>();
        await eventBus.Publish(new GetAllUsersRequestIntegrationEvent());
    }
}
