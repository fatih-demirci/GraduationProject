using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using MediatR;
using MessagePersistenceService.Application.Languages;
using MessagePersistenceService.Application.Services.HttpContextAccessorServices;
using MessagePersistenceService.Application.Services.Repositories;
using Microsoft.Extensions.Localization;

namespace MessagePersistenceService.Application.Features.ChatCategories.Queries.GetAllChatCategory;

internal class GetAllChatCategoryQueryRequestHandler : IRequestHandler<GetAllChatCategoryQueryRequest, IPaginate<GetAllChatCategoryResponseDto>>
{
    private readonly IChatCategoryRepository _chatCategoryRepository;
    private readonly IHttpContextAccessorService _httpContextAccessorService;
    private readonly IStringLocalizer<Lang> _stringLocalizer;

    public GetAllChatCategoryQueryRequestHandler(IChatCategoryRepository chatCategoryRepository, IHttpContextAccessorService httpContextAccessorService, IStringLocalizer<Lang> stringLocalizer)
    {
        _chatCategoryRepository = chatCategoryRepository;
        _httpContextAccessorService = httpContextAccessorService;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<IPaginate<GetAllChatCategoryResponseDto>> Handle(GetAllChatCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        if (!request.Status && !_httpContextAccessorService.CheckIfSuperAdmin())
        {
            throw new AuthorizationException(_stringLocalizer["AuthorizationException"]);
        }

        IPaginate<GetAllChatCategoryResponseDto> response = await _chatCategoryRepository.GetListAsync<GetAllChatCategoryResponseDto>(index: request.Index, size: request.Size, predicate: i => i.Status == request.Status, cancellationToken: cancellationToken);
        return response;
    }
}
