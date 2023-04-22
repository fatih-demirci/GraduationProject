using AutoMapper;
using System.Globalization;
using UniversityService.Application.Features.UniversityDepartments.Dtos;
using UniversityService.Application.Features.UniversityDepartments.Queries.GetAllUniversityDepartment;
using UniversityService.Domain.Entities;

namespace UniversityService.Application.Features.UniversityDepartments.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<UniversityDepartment, GetAllUniversityDepartmentResponseDto>().ForMember(x => x.Faculty, y => y.MapFrom(z => z.Faculty)).ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<Faculty, FacultyDto>()
            .ForMember(x => x.Name, y => y.MapFrom(z => z.FacultyCultures.SingleOrDefault(z => z.Culture == CultureInfo.CurrentCulture.Name) != null ? z.FacultyCultures.SingleOrDefault(z => z.Culture == CultureInfo.CurrentCulture.Name)!.Name : z.FacultyCultures.SingleOrDefault(z => z.Culture == "tr-TR")!.Name))
            .ForMember(x => x.Culture, y => y.MapFrom(z => z.FacultyCultures.SingleOrDefault(z => z.Culture == CultureInfo.CurrentCulture.Name) != null ? z.FacultyCultures.SingleOrDefault(z => z.Culture == CultureInfo.CurrentCulture.Name)!.Culture : z.FacultyCultures.SingleOrDefault(z => z.Culture == "tr-TR")!.Culture))
            .ForMember(x => x.FacultyCultureId, y => y.MapFrom(z => z.FacultyCultures.SingleOrDefault(z => z.Culture == CultureInfo.CurrentCulture.Name) != null ? z.FacultyCultures.SingleOrDefault(z => z.Culture == CultureInfo.CurrentCulture.Name)!.Id : z.FacultyCultures.SingleOrDefault(z => z.Culture == "tr-TR")!.Id))
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id)).ReverseMap().ForAllMembers(o => o.ExplicitExpansion());

        CreateMap<UniversityDepartment, GetAllUniversityDepartmentResponseDto>().ForMember(x => x.Department, y => y.MapFrom(z => z.Department)).ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<Department, DepartmentDto>()
            .ForMember(x => x.Name, y => y.MapFrom(z => z.DepartmentCultures.SingleOrDefault(z => z.Culture == CultureInfo.CurrentCulture.Name) != null ? z.DepartmentCultures.SingleOrDefault(z => z.Culture == CultureInfo.CurrentCulture.Name)!.Name : z.DepartmentCultures.SingleOrDefault(z => z.Culture == "tr-TR")!.Name))
            .ForMember(x => x.Culture, y => y.MapFrom(z => z.DepartmentCultures.SingleOrDefault(z => z.Culture == CultureInfo.CurrentCulture.Name) != null ? z.DepartmentCultures.SingleOrDefault(z => z.Culture == CultureInfo.CurrentCulture.Name)!.Culture : z.DepartmentCultures.SingleOrDefault(z => z.Culture == "tr-TR")!.Culture))
            .ForMember(x => x.DepartmentCultureId, y => y.MapFrom(z => z.DepartmentCultures.SingleOrDefault(z => z.Culture == CultureInfo.CurrentCulture.Name) != null ? z.DepartmentCultures.SingleOrDefault(z => z.Culture == CultureInfo.CurrentCulture.Name)!.Id : z.DepartmentCultures.SingleOrDefault(z => z.Culture == "tr-TR")!.Id))
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id)).ForAllMembers(o => o.ExplicitExpansion());

        CreateMap<UniversityDepartment, GetAllUniversityDepartmentResponseDto>().ForMember(x => x.University, y => y.MapFrom(z => z.University)).ForAllMembers(o => o.ExplicitExpansion());
        CreateMap<University, UniversityDto>()
            .ForMember(x => x.ProvienceName, y => y.MapFrom(z => z.Provience.Name))
            .ForMember(x => x.ProvienceId, y => y.MapFrom(z => z.Provience.Id))
            .ForMember(x => x.CountryName, y => y.MapFrom(z => z.Provience.Country.CountryCultures.SingleOrDefault(z => z.Culture == CultureInfo.CurrentCulture.Name) != null ? z.Provience.Country.CountryCultures.SingleOrDefault(z => CultureInfo.CurrentCulture.Name == z.Culture)!.Name : z.Provience.Country.CountryCultures.SingleOrDefault(z => CultureInfo.CurrentCulture.Name == "tr-TR")!.Name))
            .ForMember(x => x.CountryId, y => y.MapFrom(z => z.Provience.Country.CountryCultures.SingleOrDefault(z => z.Culture == CultureInfo.CurrentCulture.Name) != null ? z.Provience.Country.CountryCultures.SingleOrDefault(z => CultureInfo.CurrentCulture.Name == z.Culture)!.Id : z.Provience.Country.CountryCultures.SingleOrDefault(z => CultureInfo.CurrentCulture.Name == "tr-TR")!.Id))
            .ForMember(x => x.Email, y => y.MapFrom(z => z.Email))
            .ForMember(x => x.Address, y => y.MapFrom(z => z.Address))
            .ForMember(x => x.Fax, y => y.MapFrom(z => z.Fax))
            .ForMember(x => x.Type, y => y.MapFrom(z => z.Type))
            .ForMember(x => x.Phone, y => y.MapFrom(z => z.Phone))
            .ForMember(x => x.Website, y => y.MapFrom(z => z.Website))
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name)).ForAllMembers(o => o.ExplicitExpansion());
    }
}
