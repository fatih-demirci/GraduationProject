using MediatR;
using UniversityService.Application.Services.Repositories;

namespace UniversityService.Application.Features.UniversityComments.Queries.GetAllUniversityComment;

public class GetAllUniversityCommentQueryRequestHandler : IRequestHandler<GetAllUniversityCommentQueryRequest, List<GetAllUniversityCommentResponseDto>>
{
    private readonly IUniversityCommentRepository _universityCommentRepository;

    public GetAllUniversityCommentQueryRequestHandler(IUniversityCommentRepository universityCommentRepository)
    {
        _universityCommentRepository = universityCommentRepository;
    }

    public async Task<List<GetAllUniversityCommentResponseDto>> Handle(GetAllUniversityCommentQueryRequest request, CancellationToken cancellationToken)
    {
        List<GetAllUniversityCommentResponseDto> response = await _universityCommentRepository.GetListAsync<GetAllUniversityCommentResponseDto>(request.Options);
        return response;
    }
}
