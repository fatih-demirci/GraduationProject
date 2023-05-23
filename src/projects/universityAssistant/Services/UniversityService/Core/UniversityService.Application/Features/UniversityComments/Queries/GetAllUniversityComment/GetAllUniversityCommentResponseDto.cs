namespace UniversityService.Application.Features.UniversityComments.Queries.GetAllUniversityComment;

public class GetAllUniversityCommentResponseDto
{
    public int Id { get; set; }
    public int UniversityId { get; set; }
    public long UserId { get; set; }
    public string Title { get; set; }
    public string Message { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public GetAllUniversityCommentResponseDtoUser User { get; set; }
    public List<GetAllUniversityCommentResponseDtoUserUniversityCommentFile> UniversityCommentFiles { get; set; }
}

public class GetAllUniversityCommentResponseDtoUser
{
    public long Id { get; set; }
    public string UserName { get; set; }
    public string? ProfilePhotoUrl { get; set; }
}

public class GetAllUniversityCommentResponseDtoUserUniversityCommentFile
{
    public int Id { get; set; }
    public int UniversityCommentId { get; set; }
    public string Url { get; set; }
    public string FileNameForStorage { get; set; }
    public string FileType { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
}
