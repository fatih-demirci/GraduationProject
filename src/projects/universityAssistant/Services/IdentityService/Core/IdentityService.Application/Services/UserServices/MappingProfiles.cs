using AutoMapper;
using IdentityService.Application.IntegrationEvents;
using IdentityService.Domain.Entities;

namespace IdentityService.Application.Services.UserServices;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<User, GetAllUsersIntegrationEventUser>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
            .ForMember(x => x.ProfilePhotoUrl, y => y.MapFrom(z => z.ProfilePhotoUrl))
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName));
    }
}
