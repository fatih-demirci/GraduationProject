using AutoMapper;
using MediatR;
using MessagePersistenceService.Application.Features.ChatGroups.Rules;
using MessagePersistenceService.Application.Services.HttpContextAccessorServices;
using MessagePersistenceService.Application.Services.Repositories;
using MessagePersistenceService.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace MessagePersistenceService.Application.Features.ChatGroups.Commands.AddChatGroup;

public class AddChatGroupCommandRequestHandler : IRequestHandler<AddChatGroupCommandRequest, AddChatGroupResponse>
{
    private readonly IChatGroupRepository _chatGroupRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessorService _httpContextAccessorService;
    private readonly ChatGroupBusinessRules _chatGroupBusinessRules;

    public AddChatGroupCommandRequestHandler(IChatGroupRepository chatGroupRepository, IMapper mapper, IHttpContextAccessorService httpContextAccessorService, ChatGroupBusinessRules chatGroupBusinessRules)
    {
        _chatGroupRepository = chatGroupRepository;
        _mapper = mapper;
        _httpContextAccessorService = httpContextAccessorService;
        _chatGroupBusinessRules = chatGroupBusinessRules;
    }

    public async Task<AddChatGroupResponse> Handle(AddChatGroupCommandRequest request, CancellationToken cancellationToken)
    {
        await _chatGroupBusinessRules.ChatCategoryShouldExist(request.ChatCategoryId);

        ChatGroup chatGroup = _mapper.Map<ChatGroup>(request);

        chatGroup.UserId = _httpContextAccessorService.GetUserId();

        chatGroup = _chatGroupRepository.Add(chatGroup);

        await _chatGroupRepository.UnitOfWork.SaveEntitiesAsync();

        AddChatGroupResponse response = (await _chatGroupRepository.GetAsync<AddChatGroupResponse>(
            i => i.Id == chatGroup.Id,
            include: i => i.Include(x => x.User)
                           .Include(x => x.ChatCategory)))!;

        return response;
    }
}
