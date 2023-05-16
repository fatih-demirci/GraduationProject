using Core.Application.Pipelines.Authorization;
using MediatR;
using UniversityService.Application.Constants;

namespace UniversityService.Application.Features.Universities.Commands.AddUniversity;

public class AddUniversityCommandRequest : IRequest<AddUniversityResponse>, ISecuredRequest
{
    public int ProvienceId { get; set; }
    public string Name { get; set; }
    public string Website { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Address { get; set; }
    public byte Type { get; set; }

    public string[] Roles => new string[] { DbRoles.SUPERADMIN };
}
