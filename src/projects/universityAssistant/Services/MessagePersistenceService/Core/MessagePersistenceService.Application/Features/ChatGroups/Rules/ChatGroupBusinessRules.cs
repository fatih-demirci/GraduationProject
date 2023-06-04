using Core.CrossCuttingConcerns.Exceptions;
using MessagePersistenceService.Application.Languages;
using MessagePersistenceService.Application.Services.Repositories;
using Microsoft.Extensions.Localization;

namespace MessagePersistenceService.Application.Features.ChatGroups.Rules;

public class ChatGroupBusinessRules
{
    private readonly IChatCategoryRepository _chatCategoryRepository;
    private readonly IChatGroupRepository _chatGroupRepository;
    private readonly IStringLocalizer<Lang> _stringLocalizer;

    public ChatGroupBusinessRules(IChatCategoryRepository chatCategoryRepository, IStringLocalizer<Lang> stringLocalizer, IChatGroupRepository chatGroupRepository)
    {
        _chatCategoryRepository = chatCategoryRepository;
        _stringLocalizer = stringLocalizer;
        _chatGroupRepository = chatGroupRepository;
    }

    public async Task ChatCategoryShouldExist(int id)
    {
        if (!await _chatCategoryRepository.AnyAsync(i => i.Id == id))
            throw new BusinessException(_stringLocalizer["ChatCategoryDoesNotExist"]);
    }

    public async Task ChatGroupShouldExist(int id)
    {
        if (!await _chatGroupRepository.AnyAsync(i => i.Id == id))
            throw new BusinessException(_stringLocalizer["ChatGroupDoesNotExist"]);
    }
}
