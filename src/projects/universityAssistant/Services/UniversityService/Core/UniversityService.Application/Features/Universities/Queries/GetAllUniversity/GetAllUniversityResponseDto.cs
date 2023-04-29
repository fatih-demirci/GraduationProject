using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Application.Features.Universities.Queries.GetAllUniversity;

public class GetAllUniversityResponseDto
{
    public int Id { get; set; }
    public int ProvienceId { get; set; }
    public string ProvienceName { get; set; }
    public int CountryId { get; set; }
    public string CountryName { get; set; }
    public string Name { get; set; }
    public string Website { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Address { get; set; }
    public string? LogoUrl { get; set; }
    public byte Type { get; set; }
}
