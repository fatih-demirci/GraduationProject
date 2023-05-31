using Core.Application.Pipelines.Authorization;
using MediatR;
using MessagePersistenceService.Application.Constants;

namespace MessagePersistenceService.Application.Features.ChatGroups.Commands.AddChatGroup;

public class AddChatGroupCommandRequest : IRequest<AddChatGroupResponse>, ISecuredRequest
{
    public int ChatCategoryId { get; set; }
    public string Name { get; set; }

    public string[] Roles => new string[] { DbRoles.USER, DbRoles.ADMIN, DbRoles.SUPERADMIN };
}
