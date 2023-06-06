using EventBus.Base.Abstraction;
using MessageOnlineService.Api.Hubs;
using MessageOnlineService.Api.IntegrationEvents.Events;
using Microsoft.AspNetCore.SignalR;

namespace MessageOnlineService.Api.IntegrationEvents.EventHandlers;

public class UserLeavedIntegrationEventHandler : IIntegrationEventHandler<UserLeavedIntegrationEvent>
{
    private readonly IServiceProvider _serviceProvider;

    public UserLeavedIntegrationEventHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Handle(UserLeavedIntegrationEvent @event)
    {
        using IServiceScope serviceScope = _serviceProvider.CreateScope();

        IHubContext<MessageHub, IMessageHub> hubContext = serviceScope.ServiceProvider.GetRequiredService<IHubContext<MessageHub, IMessageHub>>();

        await hubContext.Clients.Group(@event.ChatGroupId.ToString()).userLeaved(@event);
    }
}
