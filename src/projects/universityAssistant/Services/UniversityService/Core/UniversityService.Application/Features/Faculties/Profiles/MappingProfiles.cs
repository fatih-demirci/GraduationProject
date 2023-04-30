using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Features.Faculties.Queries;
using UniversityService.Domain.Entities;

namespace UniversityService.Application.Features.Faculties.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Faculty, GetAllFacultyResponseDto>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Culture, y => y.MapFrom(z => z.FacultyCultures.FirstOrDefault(i => i.Culture == CultureInfo.CurrentCulture.Name) != null ? z.FacultyCultures.FirstOrDefault(i => i.Culture == CultureInfo.CurrentCulture.Name)!.Culture : z.FacultyCultures.FirstOrDefault(i => i.Culture == "tr-TR")!.Culture))
            .ForMember(x => x.FacultyCultureId, y => y.MapFrom(z => z.FacultyCultures.FirstOrDefault(i => i.Culture == CultureInfo.CurrentCulture.Name) != null ? z.FacultyCultures.FirstOrDefault(i => i.Culture == CultureInfo.CurrentCulture.Name)!.Id : z.FacultyCultures.FirstOrDefault(i => i.Culture == "tr-TR")!.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.FacultyCultures.FirstOrDefault(i => i.Culture == CultureInfo.CurrentCulture.Name) != null ? z.FacultyCultures.FirstOrDefault(i => i.Culture == CultureInfo.CurrentCulture.Name)!.Name : z.FacultyCultures.FirstOrDefault(i => i.Culture == "tr-TR")!.Name));
    }
}
