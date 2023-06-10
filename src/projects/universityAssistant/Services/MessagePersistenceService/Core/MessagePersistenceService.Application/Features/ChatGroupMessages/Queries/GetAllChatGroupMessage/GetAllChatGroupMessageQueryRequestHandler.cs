using Core.CrossCuttingConcerns.Exceptions;
using Core.Persistence.Paging;
using MediatR;
using MessagePersistenceService.Application.Languages;
using MessagePersistenceService.Application.Services.HttpContextAccessorServices;
using MessagePersistenceService.Application.Services.Repositories;
using Microsoft.Extensions.Localization;

namespace MessagePersistenceService.Application.Features.ChatGroupMessages.Queries.GetAllChatGroupMessage;

public class GetAllChatGroupMessageQueryRequestHandler : IRequestHandler<GetAllChatGroupMessageQueryRequest, IPaginate<GetAllChatGroupMessageResponseDto>>
{
    private readonly IChatGroupMessageRepository _chatGroupMessageRepository;
    private readonly IHttpContextAccessorService _httpContextAccessorService;
    private readonly IStringLocalizer<Lang> _stringLocalizer;

    public GetAllChatGroupMessageQueryRequestHandler(IChatGroupMessageRepository chatGroupMessageRepository, IHttpContextAccessorService httpContextAccessorService, IStringLocalizer<Lang> stringLocalizer)
    {
        _chatGroupMessageRepository = chatGroupMessageRepository;
        _httpContextAccessorService = httpContextAccessorService;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<IPaginate<GetAllChatGroupMessageResponseDto>> Handle(GetAllChatGroupMessageQueryRequest request, CancellationToken cancellationToken)
    {
        if (!request.Status && !_httpContextAccessorService.CheckIfSuperAdmin())
        {
            throw new AuthorizationException(_stringLocalizer["AuthorizationException"]);
        }

        IPaginate<GetAllChatGroupMessageResponseDto> response =
            await _chatGroupMessageRepository.GetListAsync<GetAllChatGroupMessageResponseDto>
            (index: request.Index, size: request.Size,
            predicate: i => i.ChatGroupId == request.ChatGroupId && i.Status == request.Status,
            orderBy: i => i.OrderBy(i => i.SendingDate),
            cancellationToken: cancellationToken);

        return response;
    }
}