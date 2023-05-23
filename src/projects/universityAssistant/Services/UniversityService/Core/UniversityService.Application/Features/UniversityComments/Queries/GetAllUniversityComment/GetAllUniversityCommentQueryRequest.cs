using MediatR;
using Microsoft.AspNetCore.OData.Query;

namespace UniversityService.Application.Features.UniversityComments.Queries.GetAllUniversityComment;

public class GetAllUniversityCommentQueryRequest : IRequest<List<GetAllUniversityCommentResponseDto>>
{
    public ODataQueryOptions<GetAllUniversityCommentResponseDto> Options { get; set; }
}
