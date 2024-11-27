using SweetDictionary.Models.Tokens.Dtos;
using SweetDictionary.Models.Users.Dtos.Requests;
using SweetDictionary.Service.Authentications.Services.Abstracts;
using SweetDictionary.Service.Tokens.Services.Abstracts;
using SweetDictionary.Service.Users.Services.Abstracts;

namespace SweetDictionary.Service.Authentications.Services.Concretes;

public class AuthenticationService(IUserService userService, IJwtService jwtService) : IAuthenticationService
{

    public async Task<TokenResponseDto> RegisterByTokenAsync(RegisterRequestDto dto)
    {
        var registerResponse = await userService.RegisterUserAsync(dto);
        var tokenResponse = await jwtService.CreateToken(registerResponse);
        return tokenResponse;
    }

    public async Task<TokenResponseDto> LoginByTokenAsync(LoginRequestDto dto)
    {
        var loginResponse = await userService.LoginAsync(dto);
        var tokenResponse = await jwtService.CreateToken(loginResponse);
        return tokenResponse;
    }
}
