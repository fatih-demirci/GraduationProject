using UniversityService.Application.Features.UniversityDepartments.Dtos;

namespace UniversityService.Application.Features.UniversityDepartments.Queries.GetAllUniversityDepartment;

public class GetAllUniversityDepartmentResponseDto
{
    public int Id { get; set; }
    public int UniversityId { get; set; }
    public int FacultyId { get; set; }
    public int DepartmentId { get; set; }
    public UniversityDto University { get; set; }
    public FacultyDto Faculty { get; set; }
    public DepartmentDto Department { get; set; }
}
