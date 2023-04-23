using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Domain.Entities;

public class Faculty : Entity
{
    public int Id { get; set; }
    public virtual List<FacultyCulture> FacultyCultures { get; set; }
}
