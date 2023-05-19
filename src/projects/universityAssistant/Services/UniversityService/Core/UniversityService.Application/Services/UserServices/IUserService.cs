using UniversityService.Domain.Entities;

namespace UniversityService.Application.Services.UserServices;

public interface IUserService
{
    Task<int> SaveEntitiesAsync();
    Task AddOrUpdateRange(List<User> users);
}
