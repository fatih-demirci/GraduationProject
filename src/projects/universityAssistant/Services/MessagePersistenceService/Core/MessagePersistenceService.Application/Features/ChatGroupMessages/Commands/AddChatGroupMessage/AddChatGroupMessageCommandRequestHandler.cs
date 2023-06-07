using AutoMapper;
using Core.CrossCuttingConcerns.Exceptions;
using EventBus.Base.Abstraction;
using MediatR;
using MessagePersistenceService.Application.Features.ChatGroupMessages.Rules;
using MessagePersistenceService.Application.IntegrationEvents;
using MessagePersistenceService.Application.Languages;
using MessagePersistenceService.Application.Services.ChatGroupServices;
using MessagePersistenceService.Application.Services.HttpContextAccessorServices;
using MessagePersistenceService.Application.Services.Repositories;
using MessagePersistenceService.Domain.Entities;
using MessagePersistenceService.Infrastructure.Storage;
using Microsoft.Extensions.Localization;

namespace MessagePersistenceService.Application.Features.ChatGroupMessages.Commands.AddChatGroupMessage;

public class AddChatGroupMessageCommandRequestHandler : IRequestHandler<AddChatGroupMessageCommandRequest, AddChatGroupMessageResponse>
{
    private readonly IChatGroupMessageRepository _chatGroupMessageRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessorService _contextAccessorService;
    private readonly IChatGroupService _chatGroupService;
    private readonly IFileService _fileService;
    private readonly ChatGroupMessageBusinessRules _chatGroupMessageBusinessRules;
    private readonly IEventBus _eventBus;
    private readonly IOnlineInChatRepository _onlineInChatRepository;
    private readonly IStringLocalizer<Lang> _stringLocalizer;

    public AddChatGroupMessageCommandRequestHandler(IChatGroupMessageRepository chatGroupMessageRepository, IMapper mapper, IHttpContextAccessorService contextAccessorService, IChatGroupService chatGroupService, IFileService fileService, ChatGroupMessageBusinessRules chatGroupMessageBusinessRules, IEventBus eventBus, IOnlineInChatRepository onlineInChatRepository, IStringLocalizer<Lang> stringLocalizer)
    {
        _chatGroupMessageRepository = chatGroupMessageRepository;
        _mapper = mapper;
        _contextAccessorService = contextAccessorService;
        _chatGroupService = chatGroupService;
        _fileService = fileService;
        _chatGroupMessageBusinessRules = chatGroupMessageBusinessRules;
        _eventBus = eventBus;
        _onlineInChatRepository = onlineInChatRepository;
        _stringLocalizer = stringLocalizer;
    }

    public async Task<AddChatGroupMessageResponse> Handle(AddChatGroupMessageCommandRequest request, CancellationToken cancellationToken)
    {
        long userId = _contextAccessorService.GetUserId();
        bool regestered = await _onlineInChatRepository.AnyAsync(i => i.ChatGroupId == request.ChatGroupId && i.UserId == userId);

        if (!regestered) throw new BusinessException(_stringLocalizer["YouShouldBeRegisteredToTheChatGroup"]);

        await _chatGroupMessageBusinessRules.ChatGroupShouldExist(request.ChatGroupId);

        ChatGroupMessage chatGroupMessage = _mapper.Map<ChatGroupMessage>(request);

        if (request.FormFiles != null && request.FormFiles.Count > 0)
        {
            List<StorageResult> storageResults = await _fileService.UploadAsync(request.FormFiles);
            chatGroupMessage.ChatGroupMessageUrls = _mapper.Map<List<ChatGroupMessageUrl>>(storageResults);
        }

        chatGroupMessage.SendingDate = DateTime.UtcNow;
        chatGroupMessage.UserId = userId;
        await _chatGroupService.UpdateLastMessageDate(chatGroupMessage.ChatGroupId);

        _chatGroupMessageRepository.Add(chatGroupMessage);

        await _chatGroupMessageRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        AddChatGroupMessageResponse response = (await _chatGroupMessageRepository.GetAsync<AddChatGroupMessageResponse>(i => i.Id == chatGroupMessage.Id))!;

        SendMessageIntegrationEvent sendMessageIntegrationEvent = _mapper.Map<SendMessageIntegrationEvent>(response);

        await _eventBus.Publish(sendMessageIntegrationEvent);

        return response;
    }
}
