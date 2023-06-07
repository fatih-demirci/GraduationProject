using AutoMapper;
using EventBus.Base.Abstraction;
using MessagePersistenceService.Api.IntegrationEvents.Events;
using MessagePersistenceService.Application.Services.Repositories;
using MessagePersistenceService.Domain.Entities;

namespace MessagePersistenceService.Api.IntegrationEvents.EventHandlers;

public class AddToGroupIntegrationEventHandler : IIntegrationEventHandler<AddToGroupIntegrationEvent>
{
    private readonly IServiceProvider _serviceProvider;

    public AddToGroupIntegrationEventHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Handle(AddToGroupIntegrationEvent @event)
    {
        using IServiceScope serviceScope = _serviceProvider.CreateScope();

        IOnlineInChatRepository onlineInChatRepository = serviceScope.ServiceProvider.GetRequiredService<IOnlineInChatRepository>();
        IMapper mapper = serviceScope.ServiceProvider.GetRequiredService<IMapper>();
        IUserRepository userRepository = serviceScope.ServiceProvider.GetRequiredService<IUserRepository>();
        IEventBus eventBus = serviceScope.ServiceProvider.GetRequiredService<IEventBus>();

        bool connectionIdExist = await onlineInChatRepository.AnyAsync(i => i.ConnectionId == @event.ConnectionId);

        if (connectionIdExist) return;

        OnlineInChat onlineInChat = mapper.Map<OnlineInChat>(@event);

        onlineInChatRepository.Add(onlineInChat);

        int clientCount = await onlineInChatRepository.CountAsync(i => i.UserId == @event.UserId && i.ChatGroupId == @event.ChatGroupId);

        if (clientCount == 0)
        {
            UserJoinedIntegrationEvent userJoinedIntegrationEvent = (await userRepository.GetAsync<UserJoinedIntegrationEvent>(i => i.Id == @event.UserId))!;
            userJoinedIntegrationEvent.ConnectionId = @event.ConnectionId;
            userJoinedIntegrationEvent.ChatGroupId = @event.ChatGroupId;

            await eventBus.Publish(userJoinedIntegrationEvent);
        }

        await onlineInChatRepository.UnitOfWork.SaveEntitiesAsync();
    }
}
