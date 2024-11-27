namespace SweetDictionary.Models.Posts.Dtos.Response;

public sealed record PostResponseDto
{
    public Guid Id { get; init; }
    public string Title { get; init; }
    public string Content { get; init; }
    public string CategoryName { get; init; }
    public string AuthorUsername { get; init; }

}
