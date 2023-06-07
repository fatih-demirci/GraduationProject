using EventBus.Base.Abstraction;
using MessagePersistenceService.Api.IntegrationEvents.Events;
using MessagePersistenceService.Application.Services.Repositories;
using MessagePersistenceService.Domain.Entities;

namespace MessagePersistenceService.Api.IntegrationEvents.EventHandlers;

public class UserDisconnectedIntegrationEventHandler : IIntegrationEventHandler<UserDisconnectedIntegrationEvent>
{
    private readonly IServiceProvider _serviceProvider;

    public UserDisconnectedIntegrationEventHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Handle(UserDisconnectedIntegrationEvent @event)
    {
        using IServiceScope serviceScope = _serviceProvider.CreateScope();

        IOnlineInChatRepository onlineInChatRepository =
            serviceScope.ServiceProvider.GetRequiredService<IOnlineInChatRepository>();

        IEventBus eventBus = serviceScope.ServiceProvider.GetRequiredService<IEventBus>();

        OnlineInChat? onlineInChat = await onlineInChatRepository.GetAsync(
            i => i.ConnectionId == @event.ConnectionId);

        if (onlineInChat != null)
        {
            onlineInChatRepository.Delete(onlineInChat);

            RemoveFromGroupIntegrationEvent removeFromGroupIntegrationEvent =
                new(@event.ConnectionId, onlineInChat.ChatGroupId);

            await eventBus.Publish(removeFromGroupIntegrationEvent);

            int clientCount = await onlineInChatRepository.CountAsync(
                i => i.UserId == onlineInChat.UserId && i.ChatGroupId == onlineInChat.ChatGroupId);

            if (clientCount == 1)
            {
                UserLeavedIntegrationEvent userLeavedIntegrationEvent =
                    new(onlineInChat.ChatGroupId, onlineInChat.ConnectionId);

                await eventBus.Publish(userLeavedIntegrationEvent);
            }

            await onlineInChatRepository.UnitOfWork.SaveEntitiesAsync();
        }
    }
}
