using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Domain.Entities;

public class University : Entity
{
    public int Id { get; set; }
    public int ProvienceId { get; set; }
    public string Name { get; set; }
    public string Website { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public string Fax { get; set; }
    public string Address { get; set; }
    public string? LogoUrl { get; set; }
    public byte Type { get; set; }
    public bool Status { get; set; }
    public virtual Provience Provience { get; set; }
    public virtual List<UniversityComment> UniversityComments { get; set; }
}
