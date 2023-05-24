using Core.Persistence.Repositories;

namespace UniversityService.Domain.Entities;

public class UniversityDepartmentInfo : Entity
{
    public int Id { get; set; }
    public int UniversityDepartmentId { get; set; }
    public int Year { get; set; }
    public float? MinimumPoint { get; set; }
    public string? MinimumSuccessRank { get; set; }
    public string Settled { get; set; }
    public string Quota { get; set; }

    public virtual UniversityDepartment UniversityDepartment { get; set; }
}
