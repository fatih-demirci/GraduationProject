using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using MediatR;
using MessagePersistenceService.Application.Languages;
using MessagePersistenceService.Application.Services.HttpContextAccessorServices;
using MessagePersistenceService.Application.Services.Repositories;
using Microsoft.Extensions.Localization;

namespace MessagePersistenceService.Application.Features.ChatGroups.Queries.GetAllChatGroup;

public class GetAllChatGroupQueryRequestHandler : IRequestHandler<GetAllChatGroupQueryRequest, IPaginate<GetAllChatGroupResponseDto>>
{
    private readonly IChatGroupRepository _chatGroupRepository;
    private readonly IHttpContextAccessorService _httpContextAccessorService;
    private readonly IStringLocalizer<Lang> _stringLocalizer;

    public GetAllChatGroupQueryRequestHandler(IChatGroupRepository chatGroupRepository, IHttpContextAccessorService httpContextAccessorService, IStringLocalizer<Lang> stringLocalizer)
    {
        _chatGroupRepository = chatGroupRepository;
        _httpContextAccessorService = httpContextAccessorService;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<IPaginate<GetAllChatGroupResponseDto>> Handle(GetAllChatGroupQueryRequest request, CancellationToken cancellationToken)
    {
        if (!request.Status && !_httpContextAccessorService.CheckIfSuperAdmin())
        {
            throw new AuthorizationException(_stringLocalizer["AuthorizationException"]);
        }

        IPaginate<GetAllChatGroupResponseDto> response =
            await _chatGroupRepository.GetListAsync<GetAllChatGroupResponseDto>(
                index: request.Index, size: request.Size,
                predicate: i => i.Status == request.Status && i.ChatCategoryId == request.ChatCategoryId,
                orderBy: i => i.OrderByDescending(i => i.LastMessageDate),
                cancellationToken: cancellationToken);

        return response;
    }
}
