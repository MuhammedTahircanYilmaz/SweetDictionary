namespace SweetDictionary.Models.Comments.Dtos.Requests;

public sealed record AddCommentRequestDto
{
    public string Content { get; init; }
    public Guid PostId { get; init; }
}
