using Core.CrossCuttingConcerns.Exceptions;
using MessagePersistenceService.Application.Languages;
using MessagePersistenceService.Application.Services.Repositories;
using Microsoft.Extensions.Localization;

namespace MessagePersistenceService.Application.Features.ChatGroups.Rules;

public class ChatGroupBusinessRules
{
    private readonly IChatCategoryRepository _chatCategoryRepository;
    private readonly IStringLocalizer<Lang> _stringLocalizer;

    public ChatGroupBusinessRules(IChatCategoryRepository chatCategoryRepository, IStringLocalizer<Lang> stringLocalizer)
    {
        _chatCategoryRepository = chatCategoryRepository;
        _stringLocalizer = stringLocalizer;
    }

    public async Task ChatCategoryShouldExist(int id)
    {
        if (!await _chatCategoryRepository.AnyAsync(i => i.Id == id))
            throw new BusinessException(_stringLocalizer["ChatCategoryDoesNotExist"]);
    }
}
