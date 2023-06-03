using AutoMapper;
using MessagePersistenceService.Application.Features.ChatCategories.Queries.GetAllChatCategory;
using MessagePersistenceService.Domain.Entities;

namespace MessagePersistenceService.Application.Features.ChatCategories.Profiles;

internal class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<ChatCategory, GetAllChatCategoryResponseDto>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name))
            .ForMember(x => x.ColorCode, y => y.MapFrom(z => z.ColorCode));
    }
}
