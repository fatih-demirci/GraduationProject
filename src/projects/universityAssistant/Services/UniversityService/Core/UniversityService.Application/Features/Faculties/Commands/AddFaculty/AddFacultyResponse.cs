using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Application.Features.Faculties.Commands.AddFaculty;

public class AddFacultyResponse
{
    public List<AddFacultyResponseFaculty> Faculties { get; set; }
}

public class AddFacultyResponseFaculty
{
    public int Id { get; set; }
    public List<AddFacultyResponseFacultyCulture> FacultyCultures { get; set; }
}

public class AddFacultyResponseFacultyCulture
{
    public int FacultyCultureId { get; set; }
    public string Culture { get; set; }
    public string Name { get; set; }
}
