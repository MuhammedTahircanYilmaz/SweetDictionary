namespace SweetDictionary.Models.Tokens.Dtos;

public sealed class TokenResponseDto
{
    public string AccessToken { get; set; }
    public DateTime ExpiryDate { get; set; }

}
