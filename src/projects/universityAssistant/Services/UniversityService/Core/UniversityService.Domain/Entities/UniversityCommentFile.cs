using Core.Persistence.Repositories;

namespace UniversityService.Domain.Entities;

public class UniversityCommentFile : Entity
{
    public int Id { get; set; }
    public int UniversityCommentId { get; set; }
    public string Url { get; set; }
    public string FileType { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public virtual UniversityComment UniversityComment { get; set; }
}

