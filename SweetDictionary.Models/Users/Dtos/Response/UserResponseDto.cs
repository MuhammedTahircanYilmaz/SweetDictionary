namespace SweetDictionary.Models.Users.Dtos.Response;

public sealed record UserResponseDto
{
    public required string Id { get; init; }
    public required string Username { get; init; }
    public required DateTime BirthDate { get; init; }
    public required string Email { get; init; }
    public required string Password { get; init; }
}
