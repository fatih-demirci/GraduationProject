using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Application.Features.Proviences.Queries.GetAllProvienceByCountryId;
using UniversityService.Domain.Entities;

namespace UniversityService.Application.Features.Proviences.Profiles;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<Provience, GetAllProvienceByCountryIdResponseDto>()
            .ForMember(x => x.Id, y => y.MapFrom(z => z.Id))
            .ForMember(x => x.CountryId, y => y.MapFrom(z => z.CountryId))
            .ForMember(x => x.Name, y => y.MapFrom(z => z.Name));
    }
}
