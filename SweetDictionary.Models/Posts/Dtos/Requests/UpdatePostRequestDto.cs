namespace SweetDictionary.Models.Posts.Dtos.Requests;
public sealed record UpdatePostRequestDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }
}
