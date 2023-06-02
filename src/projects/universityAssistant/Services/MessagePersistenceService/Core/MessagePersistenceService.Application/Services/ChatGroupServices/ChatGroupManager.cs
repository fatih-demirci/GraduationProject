using Core.CrossCuttingConcerns.Exceptions;
using MessagePersistenceService.Application.Languages;
using MessagePersistenceService.Application.Services.Repositories;
using MessagePersistenceService.Domain.Entities;
using Microsoft.Extensions.Localization;

namespace MessagePersistenceService.Application.Services.ChatGroupServices;

public class ChatGroupManager : IChatGroupService
{
    private readonly IChatGroupRepository _chatGroupRepository;
    private readonly IStringLocalizer<Lang> _stringLocalizer;

    public ChatGroupManager(IChatGroupRepository chatGroupRepository, IStringLocalizer<Lang> stringLocalizer)
    {
        _chatGroupRepository = chatGroupRepository;
        _stringLocalizer = stringLocalizer;
    }

    public async Task UpdateLastMessageDate(int id)
    {
        ChatGroup chatGroup = await _chatGroupRepository.GetAsync(i => i.Id == id) ?? throw new BusinessException(_stringLocalizer["ChatGroupDoesNotExist"]);
        chatGroup.LastMessageDate = DateTime.UtcNow;
        _chatGroupRepository.Update(chatGroup);
    }
}
