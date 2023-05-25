namespace UniversityService.Application.Features.UniversityDepartments.Dtos;

public class UniversityDepartmentInfoDto
{
    public int Id { get; set; }
    public int UniversityDepartmentId { get; set; }
    public int Year { get; set; }
    public float? MinimumPoint { get; set; }
    public string? MinimumSuccessRank { get; set; }
    public string Settled { get; set; }
    public string Quota { get; set; }
}
