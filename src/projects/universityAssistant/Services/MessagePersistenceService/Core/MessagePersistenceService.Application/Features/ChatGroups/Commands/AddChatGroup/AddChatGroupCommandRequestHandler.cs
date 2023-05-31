using AutoMapper;
using MediatR;
using MessagePersistenceService.Application.Features.ChatGroups.Rules;
using MessagePersistenceService.Application.Features.Extensions;
using MessagePersistenceService.Application.Services.Repositories;
using MessagePersistenceService.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MessagePersistenceService.Application.Features.ChatGroups.Commands.AddChatGroup;

public class AddChatGroupCommandRequestHandler : IRequestHandler<AddChatGroupCommandRequest, AddChatGroupResponse>
{
    private readonly IChatGroupRepository _chatGroupRepository;
    private readonly IMapper _mapper;
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly ChatGroupBusinessRules _chatGroupBusinessRules;

    public AddChatGroupCommandRequestHandler(IChatGroupRepository chatGroupRepository, IMapper mapper, IHttpContextAccessor httpContextAccessor, ChatGroupBusinessRules chatGroupBusinessRules)
    {
        _chatGroupRepository = chatGroupRepository;
        _mapper = mapper;
        _httpContextAccessor = httpContextAccessor;
        _chatGroupBusinessRules = chatGroupBusinessRules;
    }

    public async Task<AddChatGroupResponse> Handle(AddChatGroupCommandRequest request, CancellationToken cancellationToken)
    {
        await _chatGroupBusinessRules.ChatCategoryShouldExist(request.ChatCategoryId);

        ChatGroup chatGroup = _mapper.Map<ChatGroup>(request);

        chatGroup.UserId = _httpContextAccessor.HttpContext!.User.GetUserId();

        chatGroup = _chatGroupRepository.Add(chatGroup);

        await _chatGroupRepository.UnitOfWork.SaveEntitiesAsync();

        ChatGroup dbChatGroup = (await _chatGroupRepository.GetAsync(i => i.Id == chatGroup.Id, include: i => i.Include(x => x.User)))!;

        AddChatGroupResponse response = _mapper.Map<AddChatGroupResponse>(dbChatGroup);

        return response;
    }
}
