using AutoMapper;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Features.Countries.Queries.GetAllCountry;
using UniversityService.Domain.Entities;

namespace UniversityService.Application.Features.Countries.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Country, GetAllCountryResponseDto>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.CountryCultures.FirstOrDefault(i => i.Culture == CultureInfo.CurrentCulture.Name) != null ? z.CountryCultures.FirstOrDefault(i => i.Culture == CultureInfo.CurrentCulture.Name)!.Name : z.CountryCultures.FirstOrDefault(i => i.Culture == "tr-TR")!.Name));
    }
}
