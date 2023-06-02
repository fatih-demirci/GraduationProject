using AutoMapper;
using MessagePersistenceService.Application.Features.ChatGroupMessages.Commands.AddChatGroupMessage;
using MessagePersistenceService.Domain.Entities;
using MessagePersistenceService.Infrastructure.Storage;

namespace MessagePersistenceService.Application.Features.ChatGroupMessages.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AddChatGroupMessageCommandRequest, ChatGroupMessage>()
            .ForMember(x => x.Message, y => y.MapFrom(z => z.Message))
            .ForMember(x => x.ChatGroupId, y => y.MapFrom(z => z.ChatGroupId));

        CreateMap<ChatGroupMessage, AddChatGroupMessageResponse>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Message, y => y.MapFrom(z => z.Message))
            .ForMember(x => x.ProfilePhotoUrl, y => y.MapFrom(z => z.User.ProfilePhotoUrl))
            .ForMember(x => x.UserId, y => y.MapFrom(z => z.User.Id))
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.User.UserName))
            .ForMember(x => x.ChatGroupId, y => y.MapFrom(z => z.ChatGroupId))
            .ForMember(x => x.SendingDate, y => y.MapFrom(z => z.SendingDate))
            .ForMember(x => x.ChatGroupMessageUrls, y => y.MapFrom(z => z.ChatGroupMessageUrls));

        CreateMap<ChatGroupMessageUrl, AddChatGroupMessageResponseChatGroupMessageUrl>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.FileNameForStorage, y => y.MapFrom(z => z.FileNameForStorage))
            .ForMember(x => x.Url, y => y.MapFrom(z => z.Url))
            .ForMember(x => x.Type, y => y.MapFrom(z => z.Type));

        CreateMap<StorageResult, ChatGroupMessageUrl>()
            .ForMember(x => x.FileNameForStorage, y => y.MapFrom(z => z.FileNameForStorage))
            .ForMember(x => x.Type, y => y.MapFrom(z => z.FileType))
            .ForMember(x => x.Url, y => y.MapFrom(z => z.URL));
    }
}