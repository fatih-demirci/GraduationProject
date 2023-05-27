using MessagePersistenceService.Domain.Entities;

namespace MessagePersistenceService.Application.Services.UserServices;

public interface IUserService
{
    Task<int> SaveEntitiesAsync();
    Task AddOrUpdateRange(List<User> users);
}
