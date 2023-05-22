using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using UniversityService.Application.Features.Extensions;
using UniversityService.Application.Features.UniversityComments.Commands.AddUniversityCommand;
using UniversityService.Application.Services.Repositories;
using UniversityService.Domain.Entities;
using UniversityService.Infrastructure.Storage;

namespace UniversityService.Application.Features.UniversityComments.Commands.AddUniversityComment;

public class AddUniversityCommentCommandRequestHandler : IRequestHandler<AddUniversityCommentCommandRequest, AddUniversityCommentResponse>
{
    private readonly IUniversityCommentRepository _universityCommentRepository;
    private readonly IFileService _fileService;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _contextAccessor;

    public AddUniversityCommentCommandRequestHandler(IUniversityCommentRepository universityCommentRepository, IFileService fileService, IMapper mapper, IHttpContextAccessor contextAccessor)
    {
        _universityCommentRepository = universityCommentRepository;
        _fileService = fileService;
        _mapper = mapper;
        _contextAccessor = contextAccessor;
    }

    public async Task<AddUniversityCommentResponse> Handle(AddUniversityCommentCommandRequest request, CancellationToken cancellationToken)
    {
        UniversityComment universityComment = _mapper.Map<UniversityComment>(request);
        if (request.FormFiles != null && request.FormFiles.Count > 0)
        {
            List<StorageResult> storageResults = await _fileService.UploadAsync(request.FormFiles);
            universityComment.UniversityCommentFiles = _mapper.Map<List<UniversityCommentFile>>(storageResults);
        }
        universityComment.UserId = _contextAccessor.HttpContext.User.GetUserId();
        _universityCommentRepository.Add(universityComment);

        await _universityCommentRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        AddUniversityCommentResponse response = _mapper.Map<AddUniversityCommentResponse>(universityComment);
        return response;
    }
}
