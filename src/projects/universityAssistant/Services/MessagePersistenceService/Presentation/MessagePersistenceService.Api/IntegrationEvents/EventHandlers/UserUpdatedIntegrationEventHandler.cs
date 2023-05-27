using AutoMapper;
using EventBus.Base.Abstraction;
using MessagePersistenceService.Api.IntegrationEvents.Events;
using MessagePersistenceService.Application.Services.Repositories;
using MessagePersistenceService.Domain.Entities;

namespace MessagePersistenceService.Api.IntegrationEvents.EventHandlers;

public class UserUpdatedIntegrationEventHandler : IIntegrationEventHandler<UserUpdatedIntegrationEvent>
{
    private readonly IServiceProvider _serviceProvider;

    public UserUpdatedIntegrationEventHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Handle(UserUpdatedIntegrationEvent @event)
    {
        IServiceScope serviceScope = _serviceProvider.CreateScope();
        IUserRepository userRepository = serviceScope.ServiceProvider.GetRequiredService<IUserRepository>();
        IMapper mapper = serviceScope.ServiceProvider.GetRequiredService<IMapper>();

        List<User> users = mapper.Map<List<User>>(@event.Users);

        userRepository.UpdateRange(users);

        await userRepository.UnitOfWork.SaveEntitiesAsync();
    }
}

