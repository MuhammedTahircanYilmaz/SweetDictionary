namespace SweetDictionary.Models.Comments.Dtos.Response;

public class CommentResponseDto
{
    public Guid Id { get; init; }
    public string Content { get; init; }
    public string PostTitle { get; init; }
    public string Username { get; init; }
}
