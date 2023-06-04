using Core.CrossCuttingConcerns.Exceptions;
using MediatR;
using MessagePersistenceService.Application.Features.ChatGroups.Rules;
using MessagePersistenceService.Application.Languages;
using MessagePersistenceService.Application.Services.HttpContextAccessorServices;
using MessagePersistenceService.Application.Services.Repositories;
using Microsoft.Extensions.Localization;

namespace MessagePersistenceService.Application.Features.ChatGroups.Queries.GetByIdChatGroup;

public class GetByIdChatGroupQueryRequestHandler : IRequestHandler<GetByIdChatGroupQueryRequest, GetByIdChatGroupResponseDto>
{
    private readonly IChatGroupRepository _chatGroupRepository;
    private readonly IStringLocalizer<Lang> _stringLocalizer;
    private readonly ChatGroupBusinessRules _chatGroupBusinessRules;
    private readonly IHttpContextAccessorService _httpContextAccessorService;

    public GetByIdChatGroupQueryRequestHandler(IChatGroupRepository chatGroupRepository, IStringLocalizer<Lang> stringLocalizer, ChatGroupBusinessRules chatGroupBusinessRules, IHttpContextAccessorService httpContextAccessorService)
    {
        _chatGroupRepository = chatGroupRepository;
        _stringLocalizer = stringLocalizer;
        _chatGroupBusinessRules = chatGroupBusinessRules;
        _httpContextAccessorService = httpContextAccessorService;
    }

    public async Task<GetByIdChatGroupResponseDto> Handle(GetByIdChatGroupQueryRequest request, CancellationToken cancellationToken)
    {
        await _chatGroupBusinessRules.ChatGroupShouldExist(request.Id);

        GetByIdChatGroupResponseDto response = (await _chatGroupRepository.GetAsync<GetByIdChatGroupResponseDto>(i => i.Id == request.Id))!;

        if (!response.Status && !_httpContextAccessorService.CheckIfSuperAdmin())
            throw new BusinessException(_stringLocalizer["AuthorizationException"]);

        return response;
    }
}