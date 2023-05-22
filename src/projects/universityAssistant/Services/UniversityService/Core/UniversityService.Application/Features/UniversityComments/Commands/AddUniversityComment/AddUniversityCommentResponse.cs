namespace UniversityService.Application.Features.UniversityComments.Commands.AddUniversityComment;

public class AddUniversityCommentResponse
{
    public int Id { get; set; }
    public int UniversityId { get; set; }
    public long UserId { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public virtual List<AddUniversityCommentResponseUniversityCommentFile> UniversityCommentFiles { get; set; }
}

public class AddUniversityCommentResponseUniversityCommentFile
{
    public int Id { get; set; }
    public int UniversityCommentId { get; set; }
    public string Url { get; set; }
    public string FileNameForStorage { get; set; }
    public string FileType { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
