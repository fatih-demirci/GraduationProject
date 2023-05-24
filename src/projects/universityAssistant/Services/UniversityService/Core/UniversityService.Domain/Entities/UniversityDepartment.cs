using Core.Persistence.Repositories;

namespace UniversityService.Domain.Entities;

public class UniversityDepartment : Entity
{
    public int Id { get; set; }
    public int UniversityId { get; set; }
    public int FacultyId { get; set; }
    public int DepartmentId { get; set; }
    public string EducationType { get; set; }
    public string Price { get; set; }
    public string Language { get; set; }
    public string YopCode { get; set; }
    public List<UniversityDepartmentInfo> UniversityDepartmentInfos { get; set; }
    public University University { get; set; }
    public Faculty Faculty { get; set; }
    public Department Department { get; set; }
}
