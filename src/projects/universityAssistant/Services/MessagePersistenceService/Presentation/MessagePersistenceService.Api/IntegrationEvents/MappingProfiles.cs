using AutoMapper;
using MessagePersistenceService.Api.IntegrationEvents.Events;
using MessagePersistenceService.Domain.Entities;

namespace MessagePersistenceService.Api.IntegrationEvents;

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

        CreateMap<AddToGroupIntegrationEvent, OnlineInChat>()
            .ForMember(x => x.ChatGroupId, y => y.MapFrom(z => z.ChatGroupId))
            .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
            .ForMember(x => x.ConnectionId, y => y.MapFrom(z => z.ConnectionId));

        CreateMap<User, UserJoinedIntegrationEvent>()
            .ForMember(x => x.ProfilePhotoUrl, y => y.MapFrom(z => z.ProfilePhotoUrl))
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.UserName))
            .ForMember(x => x.UserId, y => y.MapFrom(z => z.Id));
    }
}
