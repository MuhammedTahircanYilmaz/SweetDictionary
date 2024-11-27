using SweetDictionary.Models.Tokens.Dtos;
using SweetDictionary.Models.Users.Dtos.Requests;

namespace SweetDictionary.Service.Authentications.Services.Abstracts;

public interface IAuthenticationService
{
    // Summary:
    //      Registers the user into the database and returns a JWT token
    //
    // Parameters:
    //   dto:
    //      A RegisterRequestDto that has the required fields for the registration process of a user
    //
    // Returns:
    //      A TokenResponseDto with the created token, and the expiry date for the token

    Task<TokenResponseDto> RegisterByTokenAsync(RegisterRequestDto dto);


    // Summary:
    //      Logs the user in and returns a JWT token 
    //
    // Parameters:
    //   dto:
    //      A LoginRequestDto that has the required fields for the login process of a user
    //
    // Returns:
    //      A TokenResponseDto with the created token, and the expiry date for the token

    Task<TokenResponseDto> LoginByTokenAsync(LoginRequestDto dto);
}

