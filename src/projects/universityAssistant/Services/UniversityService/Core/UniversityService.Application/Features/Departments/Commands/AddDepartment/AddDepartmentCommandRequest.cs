using Core.Application.Pipelines.Authorization;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Constants;

namespace UniversityService.Application.Features.Departments.Commands.AddDepartment;

public class AddDepartmentCommandRequest : IRequest<AddDepartmentResponse>, ISecuredRequest
{
    public List<AddDepartmentCommandRequestDepartment> AddDepartmentCommandRequestDepartments { get; set; }

    public string[] Roles => new string[] { DbRoles.SUPERADMIN };
}

public class AddDepartmentCommandRequestDepartment
{
    public List<AddDepartmentCommandRequestDepartmentCulture> DepartmentCultures { get; set; }
}

public class AddDepartmentCommandRequestDepartmentCulture
{
    public string Culture { get; set; }
    public string Name { get; set; }
}
