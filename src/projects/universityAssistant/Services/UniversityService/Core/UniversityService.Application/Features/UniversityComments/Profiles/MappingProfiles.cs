using AutoMapper;
using UniversityService.Application.Features.UniversityComments.Commands.AddUniversityCommand;
using UniversityService.Application.Features.UniversityComments.Commands.AddUniversityComment;
using UniversityService.Application.Features.UniversityComments.Queries.GetAllUniversityComment;
using UniversityService.Domain.Entities;
using UniversityService.Infrastructure.Storage;

namespace UniversityService.Application.Features.UniversityComments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<AddUniversityCommentCommandRequest, UniversityComment>()
            .ForMember(x => x.Message, y => y.MapFrom(z => z.Message))
            .ForMember(x => x.UniversityId, y => y.MapFrom(z => z.UniversityId))
            .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.CreatedDate, y => y.MapFrom(z => DateTime.UtcNow));

        CreateMap<StorageResult, UniversityCommentFile>()
            .ForMember(x => x.CreatedDate, y => y.MapFrom(z => DateTime.UtcNow))
            .ForMember(x => x.FileType, y => y.MapFrom(z => z.FileType))
            .ForMember(x => x.Url, y => y.MapFrom(z => z.URL))
            .ForMember(x => x.FileNameForStorage, y => y.MapFrom(z => z.FileNameForStorage));

        CreateMap<UniversityComment, AddUniversityCommentResponse>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.UniversityId, y => y.MapFrom(z => z.UniversityId))
            .ForMember(x => x.UserId, y => y.MapFrom(z => z.UserId))
            .ForMember(x => x.Title, y => y.MapFrom(z => z.Title))
            .ForMember(x => x.Message, y => y.MapFrom(z => z.Message))
            .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
            .ForMember(x => x.UpdatedDate, y => y.MapFrom(z => z.UpdatedDate))
            .ForMember(x => x.UniversityCommentFiles, y => y.MapFrom(z => z.UniversityCommentFiles));

        CreateMap<UniversityCommentFile, AddUniversityCommentResponseUniversityCommentFile>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.UniversityCommentId, y => y.MapFrom(z => z.UniversityCommentId))
            .ForMember(x => x.Url, y => y.MapFrom(z => z.Url))
            .ForMember(x => x.FileNameForStorage, y => y.MapFrom(z => z.FileNameForStorage))
            .ForMember(x => x.FileType, y => y.MapFrom(z => z.FileType))
            .ForMember(x => x.CreatedDate, y => y.MapFrom(z => z.CreatedDate))
            .ForMember(x => x.UpdatedDate, y => y.MapFrom(z => z.UpdatedDate));
    }
}
