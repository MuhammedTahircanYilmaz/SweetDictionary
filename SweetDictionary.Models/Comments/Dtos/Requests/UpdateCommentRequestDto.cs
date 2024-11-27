namespace SweetDictionary.Models.Comments.Dtos.Requests;

public sealed record UpdateCommentRequestDto
{
    public Guid Id { get; init; }
    public string Content { get; init; }
}
