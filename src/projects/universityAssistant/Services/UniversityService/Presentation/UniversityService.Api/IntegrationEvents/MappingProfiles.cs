using AutoMapper;
using UniversityService.Api.IntegrationEvents.Events;
using UniversityService.Domain.Entities;

namespace UniversityService.Api.IntegrationEvents;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<GetAllUsersIntegrationEventUser, User>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.ProfilePhotoUrl, y => y.MapFrom(z => z.ProfilePhotoUrl))
            .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName));

        CreateMap<UserAddedIntegrationEventUser, User>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.ProfilePhotoUrl, y => y.MapFrom(z => z.ProfilePhotoUrl))
            .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName));

        CreateMap<UserUpdatedIntegrationEventUser, User>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.ProfilePhotoUrl, y => y.MapFrom(z => z.ProfilePhotoUrl))
            .ForMember(x => x.Status, y => y.MapFrom(z => z.Status))
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName));
    }
}
