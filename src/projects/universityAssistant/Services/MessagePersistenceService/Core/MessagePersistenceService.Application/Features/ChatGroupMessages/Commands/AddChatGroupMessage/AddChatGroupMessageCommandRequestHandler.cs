using AutoMapper;
using MediatR;
using MessagePersistenceService.Application.Features.ChatGroupMessages.Rules;
using MessagePersistenceService.Application.Services.ChatGroupServices;
using MessagePersistenceService.Application.Services.HttpContextAccessorServices;
using MessagePersistenceService.Application.Services.Repositories;
using MessagePersistenceService.Domain.Entities;
using MessagePersistenceService.Infrastructure.Storage;

namespace MessagePersistenceService.Application.Features.ChatGroupMessages.Commands.AddChatGroupMessage;

public class AddChatGroupMessageCommandRequestHandler : IRequestHandler<AddChatGroupMessageCommandRequest, AddChatGroupMessageResponse>
{
    private readonly IChatGroupMessageRepository _chatGroupMessageRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessorService _contextAccessorService;
    private readonly IChatGroupService _chatGroupService;
    private readonly IFileService _fileService;
    private readonly ChatGroupMessageBusinessRules _chatGroupMessageBusinessRules;

    public AddChatGroupMessageCommandRequestHandler(IChatGroupMessageRepository chatGroupMessageRepository, IMapper mapper, IHttpContextAccessorService contextAccessorService, IChatGroupService chatGroupService, IFileService fileService, ChatGroupMessageBusinessRules chatGroupMessageBusinessRules)
    {
        _chatGroupMessageRepository = chatGroupMessageRepository;
        _mapper = mapper;
        _contextAccessorService = contextAccessorService;
        _chatGroupService = chatGroupService;
        _fileService = fileService;
        _chatGroupMessageBusinessRules = chatGroupMessageBusinessRules;
    }

    public async Task<AddChatGroupMessageResponse> Handle(AddChatGroupMessageCommandRequest request, CancellationToken cancellationToken)
    {
        await _chatGroupMessageBusinessRules.ChatGroupShouldExist(request.ChatGroupId);

        ChatGroupMessage chatGroupMessage = _mapper.Map<ChatGroupMessage>(request);

        if (request.FormFiles != null && request.FormFiles.Count > 0)
        {
            List<StorageResult> storageResults = await _fileService.UploadAsync(request.FormFiles);
            chatGroupMessage.ChatGroupMessageUrls = _mapper.Map<List<ChatGroupMessageUrl>>(storageResults);
        }

        chatGroupMessage.SendingDate = DateTime.UtcNow;
        chatGroupMessage.UserId = _contextAccessorService.GetUserId();
        await _chatGroupService.UpdateLastMessageDate(chatGroupMessage.ChatGroupId);

        _chatGroupMessageRepository.Add(chatGroupMessage);

        await _chatGroupMessageRepository.UnitOfWork.SaveEntitiesAsync(cancellationToken);

        AddChatGroupMessageResponse response = (await _chatGroupMessageRepository.GetAsync<AddChatGroupMessageResponse>(i => i.Id == chatGroupMessage.Id))!;

        return response;
    }
}
