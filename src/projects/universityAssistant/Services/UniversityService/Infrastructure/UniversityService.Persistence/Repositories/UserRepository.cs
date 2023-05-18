using AutoMapper;
using Core.Persistence.Repositories;
using UniversityService.Application.Services.Repositories;
using UniversityService.Domain.Entities;
using UniversityService.Persistence.Contexts;

namespace UniversityService.Persistence.Repositories;

public class UserRepository : EfRepositoryBase<User, UniversityServiceContext>, IUserRepository
{
    public UserRepository(UniversityServiceContext context, IMapper mapper) : base(context, mapper)
    {
    }
}
