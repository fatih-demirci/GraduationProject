namespace UniversityService.Application.Features.Departments.Commands.AddDepartment;

public class AddDepartmentResponse
{
    public List<AddDepartmentResponseDepartment> Departments { get; set; }
}

public class AddDepartmentResponseDepartment
{
    public int Id { get; set; }
    public List<AddDepartmentResponseDepartmentCulture> DepartmentCultures { get; set; }
}

public class AddDepartmentResponseDepartmentCulture
{
    public int DepartmentCultureId { get; set; }
    public string Culture { get; set; }
    public string Name { get; set; }
}
