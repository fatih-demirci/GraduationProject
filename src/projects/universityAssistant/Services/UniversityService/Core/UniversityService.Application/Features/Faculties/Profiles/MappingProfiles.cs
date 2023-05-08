using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Features.Faculties.Commands.AddFaculty;
using UniversityService.Application.Features.Faculties.Commands.UpdateFaculty;
using UniversityService.Application.Features.Faculties.Queries.GetAllFaculty;
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

        CreateMap<List<Faculty>, AddFacultyResponse>()
            .ForMember(x => x.Faculties,
            y => y.MapFrom(z => z.Select(f => new AddFacultyResponseFaculty()
            {
                Id = f.Id,
                FacultyCultures = f.FacultyCultures.Select(fc => new AddFacultyResponseFacultyCulture()
                {
                    Culture = fc.Culture,
                    FacultyCultureId = fc.Id,
                    Name = fc.Name
                }).ToList()
            })));

        CreateMap<AddFacultyCommandRequestFaculty, Faculty>()
            .ForMember(x => x.FacultyCultures, y => y.MapFrom(z => z.FacultyCultures));

        CreateMap<AddFacultyCommandRequestFacultyCulture, FacultyCulture>()
            .ForMember(x => x.Culture, y => y.MapFrom(z => z.Culture))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

        CreateMap<UpdateFacultyCommandRequest, Faculty>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.FacultyCultures, y => y.MapFrom(z => new List<FacultyCulture>()
            { new FacultyCulture()
                {
                    Id = z.FacultyCultureId,
                    Name = z.Name,
                    Culture = z.Culture,
                    FacultyId = z.Id
                }
            }));

        CreateMap<Faculty, UpdateFacultyResponse>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.FacultyCultures, y => y.MapFrom(z => z.FacultyCultures));

        CreateMap<FacultyCulture, UpdateFacultyResponseFacultyCulture>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Culture, y => y.MapFrom(z => z.Culture))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
    }
}
