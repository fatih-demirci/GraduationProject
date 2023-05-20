using Core.Persistence.Repositories;

namespace UniversityService.Domain.Entities;

public class UniversityComment : Entity
{
    public int Id { get; set; }
    public int UniversityId { get; set; }
    public long UserId { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public virtual University University { get; set; }
    public virtual User User { get; set; }
    public virtual List<UniversityCommentFile> UniversityCommentFiles { get; set; }
}