using AutoMapper;
using IdentityService.Application.IntegrationEvents;
using IdentityService.Domain.Entities;

namespace IdentityService.Application.Features.Auths.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, UserAddedIntegrationEvent>()
            .ForMember(x => x.Users, y => y.MapFrom(z => new List<UserAddedIntegrationEventUser>()
            {
                new()
                {
                    Id = z.Id,
                    UserName = z.UserName,
                    ProfilePhotoUrl = z.ProfilePhotoUrl,
                    Status = z.Status,
                }
            }));

        CreateMap<List<User>, UserAddedIntegrationEvent>()
           .ForMember(x => x.Users, y => y.MapFrom(z => z.Select(i =>
               new UserAddedIntegrationEventUser()
               {
                   Id = i.Id,
                   UserName = i.UserName,
                   ProfilePhotoUrl = i.ProfilePhotoUrl,
                   Status = i.Status
               }
               )));
    }
}
