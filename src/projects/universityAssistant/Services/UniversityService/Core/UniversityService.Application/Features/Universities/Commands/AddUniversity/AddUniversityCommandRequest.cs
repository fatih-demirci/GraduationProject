using MediatR;

namespace UniversityService.Application.Features.Universities.Commands.AddUniversity;

public class AddUniversityCommandRequest : IRequest<AddUniversityResponse>
{
    public int ProvienceId { get; set; }
    public string Name { get; set; }
    public string Website { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Address { get; set; }
    public byte Type { get; set; }
}
