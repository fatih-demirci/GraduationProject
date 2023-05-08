using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Constants;

namespace UniversityService.Application.Features.Faculties.Commands.UpdateFaculty;

public class UpdateFacultyCommandRequest : IRequest<UpdateFacultyResponse>, ISecuredRequest
{
    public int Id { get; set; }
    public int FacultyCultureId { get; set; }
    public string Culture { get; set; }
    public string Name { get; set; }

    public string[] Roles => new string[] { DbRoles.SUPERADMIN };
}
