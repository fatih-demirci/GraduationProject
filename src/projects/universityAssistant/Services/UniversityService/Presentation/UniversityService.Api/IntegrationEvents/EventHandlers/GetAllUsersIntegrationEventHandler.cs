using AutoMapper;
using EventBus.Base.Abstraction;
using UniversityService.Api.IntegrationEvents.Events;
using UniversityService.Application.Services.UserServices;
using UniversityService.Domain.Entities;

namespace UniversityService.Api.IntegrationEvents.EventHandlers;

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
