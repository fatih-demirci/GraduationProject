using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Application.Features.UniversityDepartments.Commands.AddUniversityDepartment;

public class AddUniversityDepartmentCommandRequest : IRequest<AddUniversityDepartmentResponse>
{
    public List<AddUniversityDepartmentCommandRequestUniversity> Universities { get; set; }
}

public class AddUniversityDepartmentCommandRequestUniversity
{
    public int UniversityId { get; set; }
    public List<AddUniversityDepartmentCommandRequestFaculty> Faculties { get; set; }

}

public class AddUniversityDepartmentCommandRequestFaculty
{
    public int FacultyId { get; set; }
    public List<AddUniversityDepartmentCommandRequestDepartment> Departments { get; set; }
}

public class AddUniversityDepartmentCommandRequestDepartment
{
    public int DepartmentId { get; set; }
}