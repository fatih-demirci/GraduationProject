using MessagePersistenceService.Application.Services.Repositories;
using MessagePersistenceService.Domain.Entities;

namespace MessagePersistenceService.Application.Services.UserServices;

public class UserManager : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserManager(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task AddOrUpdateRange(List<User> users)
    {
        foreach (User user in users)
        {
            bool dbUserExist = await _userRepository.AnyAsync(u => u.Id == user.Id);
            if (dbUserExist)
            {
                _userRepository.Update(user);
            }
            else
            {
                _userRepository.Add(user);
            }
        }
    }

    public async Task<int> SaveEntitiesAsync()
    {
        return await _userRepository.UnitOfWork.SaveEntitiesAsync();
    }
}
