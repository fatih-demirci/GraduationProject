using AutoMapper;
using MessagePersistenceService.Application.Features.OnlineInChats.Queries.GetAllOnlineInChat;
using MessagePersistenceService.Domain.Entities;

namespace MessagePersistenceService.Application.Features.OnlineInChats.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<OnlineInChat, GetAllOnlineInChatResponseDto>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.User.UserName))
            .ForMember(x => x.ProfilePhotoUrl, y => y.MapFrom(z => z.User.ProfilePhotoUrl));
    }
}
