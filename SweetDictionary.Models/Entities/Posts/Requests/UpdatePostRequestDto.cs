namespace SweetDictionary.Models.Entities.Posts.Requests;
public sealed record UpdatePostRequestDto(string Title, string Content, Guid Id);
