using EventBus.Base.Abstraction;
using MessageOnlineService.Api.Hubs;
using MessageOnlineService.Api.IntegrationEvents.Events;
using Microsoft.AspNetCore.SignalR;

namespace MessageOnlineService.Api.IntegrationEvents.EventHandlers;

public class RemoveFromGroupIntegrationEventHandler : IIntegrationEventHandler<RemoveFromGroupIntegrationEvent>
{
    private readonly IServiceProvider _serviceProvider;

    public RemoveFromGroupIntegrationEventHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Handle(RemoveFromGroupIntegrationEvent @event)
    {
        using IServiceScope serviceScope = _serviceProvider.CreateScope();

        IHubContext<MessageHub, IMessageHub> hubContext = serviceScope.ServiceProvider.GetRequiredService<IHubContext<MessageHub, IMessageHub>>();

        await hubContext.Groups.RemoveFromGroupAsync(@event.ConnectionId, @event.ChatGroupId.ToString());
    }
}