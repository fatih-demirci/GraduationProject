using Core.Persistence.Paging;
using IdentityService.Application.IntegrationEvents;
using IdentityService.Application.Services.Repositories;

namespace IdentityService.Application.Services.UserServices;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task<GetAllUsersIntegrationEvent> GetAllUsersIntegrationEvent()
    {
        IPaginate<GetAllUsersIntegrationEventUser> users = await _userRepository.GetListAsync<GetAllUsersIntegrationEventUser>(size: int.MaxValue, orderBy: x => x.OrderBy(y => y.Id));
        GetAllUsersIntegrationEvent getAllUsersIntegrationEvent = new() { Users = users.Items.ToList() };
        return getAllUsersIntegrationEvent;
    }
}
