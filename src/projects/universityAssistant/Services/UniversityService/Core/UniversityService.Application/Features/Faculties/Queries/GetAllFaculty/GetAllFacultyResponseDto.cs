using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Application.Features.Faculties.Queries.GetAllFaculty;

public class GetAllFacultyResponseDto
{
    public int Id { get; set; }
    public int FacultyCultureId { get; set; }
    public string Culture { get; set; }
    public string Name { get; set; }
}
