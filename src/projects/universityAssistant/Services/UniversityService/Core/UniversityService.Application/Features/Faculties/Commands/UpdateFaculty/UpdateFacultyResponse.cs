using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Application.Features.Faculties.Commands.UpdateFaculty;

public class UpdateFacultyResponse
{
    public int Id { get; set; }
    public List<UpdateFacultyResponseFacultyCulture> FacultyCultures { get; set; }
}

public class UpdateFacultyResponseFacultyCulture
{
    public int Id { get; set; }
    public string Culture { get; set; }
    public string Name { get; set; }
}

