using AutoMapper;
using MessagePersistenceService.Application.Features.ChatGroups.Commands.AddChatGroup;
using MessagePersistenceService.Application.Features.ChatGroups.Queries.GetAllChatGroup;
using MessagePersistenceService.Domain.Entities;

namespace MessagePersistenceService.Application.Features.ChatGroups.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AddChatGroupCommandRequest, ChatGroup>()
            .ForMember(x => x.ChatCategoryId, y => y.MapFrom(z => z.ChatCategoryId))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.Status, y => y.MapFrom(z => true));

        CreateMap<ChatGroup, AddChatGroupResponse>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.ChatCategoryName, y => y.MapFrom(z => z.ChatCategory.Name))
            .ForMember(x => x.ChatCategoryId, y => y.MapFrom(z => z.ChatCategoryId))
            .ForMember(x => x.LastMessageDate, y => y.MapFrom(z => z.LastMessageDate))
            .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
            .ForMember(x => x.ProfilePhotoUrl, y => y.MapFrom(z => z.User.ProfilePhotoUrl))
            .ForMember(x => x.UserId, y => y.MapFrom(z => z.User.Id))
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.User.UserName));

        CreateMap<ChatGroup, GetAllChatGroupResponseDto>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.ChatCategoryId, y => y.MapFrom(z => z.ChatCategoryId))
            .ForMember(x => x.ChatCategoryName, y => y.MapFrom(z => z.ChatCategory.Name))
            .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
            .ForMember(x => x.UserName, y => y.MapFrom(z => z.User.UserName))
            .ForMember(x => x.ProfilePhotoUrl, y => y.MapFrom(z => z.User.ProfilePhotoUrl))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.ChatCategoryName, y => y.MapFrom(z => z.ChatCategory.Name))
            .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
            .ForMember(x => x.LastMessageDate, y => y.MapFrom(z => z.LastMessageDate));
    }
}