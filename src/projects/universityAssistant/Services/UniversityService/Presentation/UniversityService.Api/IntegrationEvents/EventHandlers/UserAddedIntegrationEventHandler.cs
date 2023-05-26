using AutoMapper;
using EventBus.Base.Abstraction;
using UniversityService.Api.IntegrationEvents.Events;
using UniversityService.Application.Services.Repositories;
using UniversityService.Domain.Entities;

namespace UniversityService.Api.IntegrationEvents.EventHandlers;

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