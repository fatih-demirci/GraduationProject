using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UniversityService.Domain.Entities;

namespace UniversityService.Application.Features.Proviences.Queries.GetAllProvienceByCountryId;

public class GetAllProvienceByCountryIdResponseDto
{
    public int Id { get; set; }
    public int CountryId { get; set; }
    public string Name { get; set; }
}
