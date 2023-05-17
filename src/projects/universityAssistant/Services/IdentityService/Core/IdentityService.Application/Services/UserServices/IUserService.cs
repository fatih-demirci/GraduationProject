using IdentityService.Application.IntegrationEvents;

namespace IdentityService.Application.Services.UserServices;

public interface IUserService
{
    Task<GetAllUsersIntegrationEvent> GetAllUsersIntegrationEvent();
}
