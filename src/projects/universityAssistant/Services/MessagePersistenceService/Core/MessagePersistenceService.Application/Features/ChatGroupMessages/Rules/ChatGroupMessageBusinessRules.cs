using Core.CrossCuttingConcerns.Exceptions;
using MessagePersistenceService.Application.Languages;
using MessagePersistenceService.Application.Services.Repositories;
using Microsoft.Extensions.Localization;

namespace MessagePersistenceService.Application.Features.ChatGroupMessages.Rules;

public class ChatGroupMessageBusinessRules
{
    private readonly IChatGroupRepository _chatGroupRepository;
    private readonly IStringLocalizer<Lang> _stringLocalizer;

    public ChatGroupMessageBusinessRules(IChatGroupRepository chatGroupRepository, IStringLocalizer<Lang> stringLocalizer)
    {
        _chatGroupRepository = chatGroupRepository;
        _stringLocalizer = stringLocalizer;
    }

    public async Task ChatGroupShouldExist(int id)
    {
        if (!await _chatGroupRepository.AnyAsync(i => i.Id == id))
            throw new BusinessException(_stringLocalizer["ChatGroupDoesNotExist"]);
    }
}
