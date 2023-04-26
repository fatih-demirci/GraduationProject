using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Application.Features.UniversityDepartments.Dtos;

public class DepartmentDto
{
    public int Id { get; set; }
    public int DepartmentCultureId { get; set; }
    public string Culture { get; set; }
    public string Name { get; set; }
}
