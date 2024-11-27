namespace SweetDictionary.Models.Posts.Dtos.Requests;

public sealed record CreatePostRequestDto
{
    public string Title { get; init; }
    public string Content { get; init; }
    public int CategoryId { get; init; }
}
