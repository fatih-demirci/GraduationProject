using EventBus.Base.Abstraction;
using IdentityService.Api.IntegrationEvents.Events;
using IdentityService.Application.IntegrationEvents;
using IdentityService.Application.Services.UserServices;

namespace IdentityService.Api.IntegrationEvents.EventHandlers;

public class GetAllUsersRequestIntegrationEventHandler : IIntegrationEventHandler<GetAllUsersRequestIntegrationEvent>
{
    private readonly IServiceProvider _services;

    public GetAllUsersRequestIntegrationEventHandler(IServiceProvider services)
    {
        _services = services;
    }

    public async Task Handle(GetAllUsersRequestIntegrationEvent @event)
    {
        using IServiceScope serviceScope = _services.CreateScope();

        IUserService userService = serviceScope.ServiceProvider.GetRequiredService<IUserService>();
        IEventBus eventBus = serviceScope.ServiceProvider.GetRequiredService<IEventBus>();

        GetAllUsersIntegrationEvent getAllUsersIntegrationEvent = await userService.GetAllUsersIntegrationEvent();
        await eventBus.Publish(getAllUsersIntegrationEvent);
    }
}
