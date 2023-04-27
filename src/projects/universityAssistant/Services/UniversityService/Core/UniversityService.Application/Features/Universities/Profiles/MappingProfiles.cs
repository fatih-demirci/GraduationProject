using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Features.Universities.Queries.GetAllUniversity;
using UniversityService.Domain.Entities;

namespace UniversityService.Application.Features.Universities.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<University, GetAllUniversityResponseDto>()
            .ForMember(x => x.ProvienceName, y => y.MapFrom(z => z.Provience.Name))
            .ForMember(x => x.ProvienceId, y => y.MapFrom(z => z.Provience.Id))
            .ForMember(x => x.CountryName, y => y.MapFrom(z => z.Provience.Country.CountryCultures.SingleOrDefault(z => z.Culture == CultureInfo.CurrentCulture.Name) != null ? z.Provience.Country.CountryCultures.SingleOrDefault(z => CultureInfo.CurrentCulture.Name == z.Culture)!.Name : z.Provience.Country.CountryCultures.SingleOrDefault(z => CultureInfo.CurrentCulture.Name == "tr-TR")!.Name))
            .ForMember(x => x.CountryId, y => y.MapFrom(z => z.Provience.Country.Id))
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
