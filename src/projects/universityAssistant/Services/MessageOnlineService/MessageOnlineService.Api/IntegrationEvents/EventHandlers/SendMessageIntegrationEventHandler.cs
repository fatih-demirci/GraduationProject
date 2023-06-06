using EventBus.Base.Abstraction;
using MessageOnlineService.Api.Hubs;
using MessageOnlineService.Api.IntegrationEvents.Events;
using Microsoft.AspNetCore.SignalR;

namespace MessageOnlineService.Api.IntegrationEvents.EventHandlers;

public class SendMessageIntegrationEventHandler : IIntegrationEventHandler<SendMessageIntegrationEvent>
{
    private readonly IServiceProvider _serviceProvider;

    public SendMessageIntegrationEventHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Handle(SendMessageIntegrationEvent @event)
    {
        using IServiceScope serviceScope = _serviceProvider.CreateScope();

        IHubContext<MessageHub, IMessageHub> hubContext = serviceScope.ServiceProvider.GetRequiredService<IHubContext<MessageHub, IMessageHub>>();
        await hubContext.Clients.Group(@event.ChatGroupId.ToString()).receiveMessage(@event);
    }
}
