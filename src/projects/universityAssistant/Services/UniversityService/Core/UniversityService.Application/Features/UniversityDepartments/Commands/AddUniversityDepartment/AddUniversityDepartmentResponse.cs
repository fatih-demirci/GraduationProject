namespace UniversityService.Application.Features.UniversityDepartments.Commands.AddUniversityDepartment;

public class AddUniversityDepartmentResponse
{
    public List<AddUniversityDepartmentResponseUniversityDepartment> UniversityDepartments { get; set; }
}

public class AddUniversityDepartmentResponseUniversityDepartment
{
    public int Id { get; set; }
    public int UniversityId { get; set; }
    public int FacultyId { get; set; }
    public int DepartmentId { get; set; }
}