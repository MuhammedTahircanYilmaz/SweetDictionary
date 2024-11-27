namespace SweetDictionary.Models.Users.Dtos.Requests;

public sealed record LoginRequestDto
{
    public string? Username { get; init; }
    public string? Email { get; init; }
    public required string Password { get; init; }

}
