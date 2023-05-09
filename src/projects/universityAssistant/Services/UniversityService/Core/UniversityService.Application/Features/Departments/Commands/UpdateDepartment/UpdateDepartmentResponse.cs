namespace UniversityService.Application.Features.Departments.Commands.UpdateDepartment;

public class UpdateDepartmentResponse
{
    public int Id { get; set; }
    public List<UpdateDepartmentResponseDepartmentCulture> DepartmentCultures { get; set; }
}

public class UpdateDepartmentResponseDepartmentCulture
{
    public int Id { get; set; }
    public string Culture { get; set; }
    public string Name { get; set; }
}
