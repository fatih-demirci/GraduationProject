using EventBus.Base.Abstraction;
using MessageOnlineService.Api.Hubs;
using MessageOnlineService.Api.IntegrationEvents.Events;
using Microsoft.AspNetCore.SignalR;

namespace MessageOnlineService.Api.IntegrationEvents.EventHandlers;

public class UserJoinedIntegrationEventHandler : IIntegrationEventHandler<UserJoinedIntegrationEvent>
{
    private readonly IServiceProvider _serviceProvider;

    public UserJoinedIntegrationEventHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Handle(UserJoinedIntegrationEvent @event)
    {
        using IServiceScope serviceScope = _serviceProvider.CreateScope();

        IHubContext<MessageHub, IMessageHub> hubContext = serviceScope.ServiceProvider.GetRequiredService<IHubContext<MessageHub, IMessageHub>>();

        await hubContext.Clients.Group(@event.ChatGroupId.ToString()).userJoined(@event);
    }
}