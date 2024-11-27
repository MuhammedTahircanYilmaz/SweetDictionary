namespace SweetDictionary.Models.Users.Dtos.Requests;

public sealed record RegisterRequestDto
{
    public required string Username { get; init; }
    public required DateTime BirthDate { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}
