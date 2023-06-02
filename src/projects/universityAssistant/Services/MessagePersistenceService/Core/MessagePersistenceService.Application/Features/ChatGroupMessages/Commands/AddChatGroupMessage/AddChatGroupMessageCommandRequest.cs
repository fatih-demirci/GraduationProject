using Core.Application.Pipelines.Authorization;
using MediatR;
using MessagePersistenceService.Application.Constants;
using Microsoft.AspNetCore.Http;

namespace MessagePersistenceService.Application.Features.ChatGroupMessages.Commands.AddChatGroupMessage;

public class AddChatGroupMessageCommandRequest : IRequest<AddChatGroupMessageResponse>, ISecuredRequest
{
    public int ChatGroupId { get; set; }
    public string Message { get; set; }
    public IFormFileCollection? FormFiles { get; set; }

    public string[] Roles => new string[] { DbRoles.USER, DbRoles.ADMIN, DbRoles.SUPERADMIN };
}