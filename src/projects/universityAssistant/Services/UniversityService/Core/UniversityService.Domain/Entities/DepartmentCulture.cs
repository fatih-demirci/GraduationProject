using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Domain.Entities;

public class DepartmentCulture : Entity
{
    public int Id { get; set; }
    public string Culture { get; set; }
    public string Name { get; set; }
    public int DepartmentId { get; set; }
    public virtual Department Department { get; set; }
}
