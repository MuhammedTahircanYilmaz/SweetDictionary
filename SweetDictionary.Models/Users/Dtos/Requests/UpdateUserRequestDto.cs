namespace SweetDictionary.Models.Users.Dtos.Requests;

public sealed record UpdateUserRequestDto
{
    public string? Username { get; init; }
    public DateTime? BirthDate { get; set; }
}
