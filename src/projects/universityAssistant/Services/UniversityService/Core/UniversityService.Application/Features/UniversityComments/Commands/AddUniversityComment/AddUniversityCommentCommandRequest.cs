using Core.Application.Pipelines.Authorization;
using MediatR;
using Microsoft.AspNetCore.Http;
using UniversityService.Application.Constants;
using UniversityService.Application.Features.UniversityComments.Commands.AddUniversityComment;

namespace UniversityService.Application.Features.UniversityComments.Commands.AddUniversityCommand;

public class AddUniversityCommentCommandRequest : IRequest<AddUniversityCommentResponse>, ISecuredRequest
{
    public int UniversityId { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public IFormFileCollection? FormFiles { get; set; }

    public string[] Roles => new string[] { DbRoles.USER, DbRoles.ADMIN, DbRoles.SUPERADMIN };
}
