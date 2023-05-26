using AutoMapper;
using IdentityService.Application.Features.Users.Commands.Update;
using IdentityService.Application.Features.Users.Dtos;
using IdentityService.Application.IntegrationEvents;
using IdentityService.Domain.Entities;

namespace IdentityService.Application.Features.Users.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UserUpdateCommandRequest, User>();
            CreateMap<User, UserUpdateResponseDto>();
            CreateMap<User, GetUserResponseDto>();

            CreateMap<User, UserUpdatedIntegrationEvent>()
                .ForMember(x => x.Users, y => y.MapFrom(z => new List<UserUpdatedIntegrationEventUser>()
                    {
                        new()
                        {
                            Id = z.Id,
                            UserName = z.UserName,
                            ProfilePhotoUrl = z.ProfilePhotoUrl,
                            Status = z.Status,
                        }
                    }));

            CreateMap<List<User>, UserUpdatedIntegrationEvent>()
               .ForMember(x => x.Users, y => y.MapFrom(z => z.Select(i =>
                   new UserUpdatedIntegrationEventUser()
                   {
                       Id = i.Id,
                       UserName = i.UserName,
                       ProfilePhotoUrl = i.ProfilePhotoUrl,
                       Status = i.Status
                   }
                   )));
        }
    }
}
