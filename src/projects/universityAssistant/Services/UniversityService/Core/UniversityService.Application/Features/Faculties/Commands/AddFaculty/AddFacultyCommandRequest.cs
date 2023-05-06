using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Constants;

namespace UniversityService.Application.Features.Faculties.Commands.AddFaculty;

public class AddFacultyCommandRequest : IRequest<AddFacultyResponse>, ISecuredRequest
{
    public List<AddFacultyCommandRequestFaculty> AddFacultyCommandRequestFaculties { get; set; }

    public string[] Roles => new string[] { DbRoles.SUPERADMIN };
}

public class AddFacultyCommandRequestFaculty
{
    public List<AddFacultyCommandRequestFacultyCulture> FacultyCultures { get; set; }
}

public class AddFacultyCommandRequestFacultyCulture
{
    public string Culture { get; set; }
    public string Name { get; set; }
}
