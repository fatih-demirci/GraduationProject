using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using MediatR;
using MessagePersistenceService.Application.Constants;
using MessagePersistenceService.Application.Languages;
using MessagePersistenceService.Application.Services.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Localization;

namespace MessagePersistenceService.Application.Features.ChatCategories.Queries.GetAllChatCategory;

internal class GetAllChatCategoryQueryRequestHandler : IRequestHandler<GetAllChatCategoryQueryRequest, IPaginate<GetAllChatCategoryResponseDto>>
{
    private readonly IChatCategoryRepository _chatCategoryRepository;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly IStringLocalizer<Lang> _stringLocalizer;

    public GetAllChatCategoryQueryRequestHandler(IChatCategoryRepository chatCategoryRepository, IHttpContextAccessor httpContextAccessor, IStringLocalizer<Lang> stringLocalizer)
    {
        _chatCategoryRepository = chatCategoryRepository;
        _httpContextAccessor = httpContextAccessor;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<IPaginate<GetAllChatCategoryResponseDto>> Handle(GetAllChatCategoryQueryRequest request, CancellationToken cancellationToken)
    {
        if (!request.Status && (_httpContextAccessor.HttpContext == null || !_httpContextAccessor.HttpContext.User.Claims.Any(i => i.Value == DbRoles.SUPERADMIN)))
        {
            throw new AuthorizationException(_stringLocalizer["AuthorizationException"]);
        }

        IPaginate<GetAllChatCategoryResponseDto> response = await _chatCategoryRepository.GetListAsync<GetAllChatCategoryResponseDto>(index: request.Index, size: request.Size, predicate: i => i.Status == request.Status, cancellationToken: cancellationToken);
        return response;
    }
}
