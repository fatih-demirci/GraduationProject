using AutoMapper;
using EventBus.Base.Abstraction;
using MessagePersistenceService.Api.IntegrationEvents.Events;
using MessagePersistenceService.Application.Services.UserServices;
using MessagePersistenceService.Domain.Entities;

namespace MessagePersistenceService.Api.IntegrationEvents.EventHandlers;

public class GetAllUsersIntegrationEventHandler : IIntegrationEventHandler<GetAllUsersIntegrationEvent>
{
    private readonly IServiceProvider _serviceProvider;

    public GetAllUsersIntegrationEventHandler(IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task Handle(GetAllUsersIntegrationEvent @event)
    {
        if (@event.Users.Count == 0) return;

        using IServiceScope serviceScope = _serviceProvider.CreateScope();

        IUserService userService = serviceScope.ServiceProvider.GetRequiredService<IUserService>();
        IMapper mapper = serviceScope.ServiceProvider.GetRequiredService<IMapper>();

        List<User> users = mapper.Map<List<User>>(@event.Users);

        await userService.AddOrUpdateRange(users);

        await userService.SaveEntitiesAsync();
    }
}
