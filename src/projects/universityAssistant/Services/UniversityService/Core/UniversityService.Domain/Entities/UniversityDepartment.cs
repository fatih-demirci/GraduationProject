using Core.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversityService.Domain.Entities;

public class UniversityDepartment : Entity
{
    public int Id { get; set; }
    public int UniversityId { get; set; }
    public int FacultyId { get; set; }
    public int DepartmentId { get; set; }
    public University University { get; set; }
    public Faculty Faculty { get; set; }
    public Department Department { get; set; }
}
