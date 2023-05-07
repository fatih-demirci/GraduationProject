using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Features.Departments.Commands.AddDepartment;
using UniversityService.Application.Features.Departments.Queries.GetAllDepartment;
using UniversityService.Domain.Entities;

namespace UniversityService.Application.Features.Departments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Department, GetAllDepartmentResponseDto>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Culture, y => y.MapFrom(z => z.DepartmentCultures.FirstOrDefault(i => i.Culture == CultureInfo.CurrentCulture.Name) != null ? z.DepartmentCultures.FirstOrDefault(i => i.Culture == CultureInfo.CurrentCulture.Name)!.Culture : z.DepartmentCultures.FirstOrDefault(i => i.Culture == "tr-TR")!.Culture))
            .ForMember(x => x.DepartmentCultureId, y => y.MapFrom(z => z.DepartmentCultures.FirstOrDefault(i => i.Culture == CultureInfo.CurrentCulture.Name) != null ? z.DepartmentCultures.FirstOrDefault(i => i.Culture == CultureInfo.CurrentCulture.Name)!.Id : z.DepartmentCultures.FirstOrDefault(i => i.Culture == "tr-TR")!.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.DepartmentCultures.FirstOrDefault(i => i.Culture == CultureInfo.CurrentCulture.Name) != null ? z.DepartmentCultures.FirstOrDefault(i => i.Culture == CultureInfo.CurrentCulture.Name)!.Name : z.DepartmentCultures.FirstOrDefault(i => i.Culture == "tr-TR")!.Name));

        CreateMap<AddDepartmentCommandRequestDepartment, Department>()
            .ForMember(x => x.DepartmentCultures, y => y.MapFrom(z => z.DepartmentCultures));

        CreateMap<AddDepartmentCommandRequestDepartmentCulture, DepartmentCulture>()
            .ForMember(x => x.Culture, y => y.MapFrom(z => z.Culture))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));

        CreateMap<List<Department>, AddDepartmentResponse>()
            .ForMember(x => x.Departments, y => y.MapFrom(z => z.Select(d => new AddDepartmentResponseDepartment()
            {
                Id = d.Id,
                DepartmentCultures = d.DepartmentCultures.Select(dc => new AddDepartmentResponseDepartmentCulture()
                {
                    Culture = dc.Culture,
                    Name = dc.Name,
                    DepartmentCultureId = dc.Id
                }).ToList()
            })));
    }
}
