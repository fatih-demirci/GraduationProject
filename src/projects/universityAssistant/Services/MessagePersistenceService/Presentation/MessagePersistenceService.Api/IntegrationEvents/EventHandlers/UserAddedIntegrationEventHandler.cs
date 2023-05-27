using AutoMapper;
using EventBus.Base.Abstraction;
using MessagePersistenceService.Api.IntegrationEvents.Events;
using MessagePersistenceService.Application.Services.Repositories;
using MessagePersistenceService.Domain.Entities;

namespace MessagePersistenceService.Api.IntegrationEvents.EventHandlers;

public class UserAddedIntegrationEventHandler : IIntegrationEventHandler<UserAddedIntegrationEvent>
{
    private readonly IServiceProvider _serviceProvider;

    public UserAddedIntegrationEventHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Handle(UserAddedIntegrationEvent @event)
    {
        IServiceScope serviceScope = _serviceProvider.CreateScope();
        IUserRepository userRepository = serviceScope.ServiceProvider.GetRequiredService<IUserRepository>();
        IMapper mapper = serviceScope.ServiceProvider.GetRequiredService<IMapper>();

        List<User> users = mapper.Map<List<User>>(@event.Users);

        userRepository.AddRange(users);

        await userRepository.UnitOfWork.SaveEntitiesAsync();
    }
}