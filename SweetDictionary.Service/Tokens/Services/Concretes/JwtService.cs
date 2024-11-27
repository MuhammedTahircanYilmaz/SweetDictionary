using Core.Tokens.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Tokens.Dtos;
using SweetDictionary.Service.Tokens.Services.Abstracts;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SweetDictionary.Service.Tokens.Services.Concretes;

public class JwtService : IJwtService
{
    private readonly CustomTokenOptions _tokenOptions;
    private readonly UserManager<User> _userManager;
    public JwtService(IOptions<CustomTokenOptions> options, UserManager<User> userManager)
    {
        _tokenOptions = options.Value;
        _userManager = userManager;
    }
    public async Task<TokenResponseDto> CreateToken(User user)
    {
        var accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
        var securityKey = SecurityKeyHelper.GetSecurityKey(_tokenOptions.SecurityKey);

        SigningCredentials signingCredentials = new(securityKey, SecurityAlgorithms.HmacSha512Signature);

        JwtSecurityToken jwtSecurityToken = new JwtSecurityToken(
            issuer: _tokenOptions.Issuer,
            expires: accessTokenExpiration,
            claims: await GetClaims(user, _tokenOptions.Audience),
            signingCredentials: signingCredentials
            );

        var jwtHandler = new JwtSecurityTokenHandler();

        string token = jwtHandler.WriteToken(jwtSecurityToken);

        return new TokenResponseDto
        {
            AccessToken = token,
            ExpiryDate = accessTokenExpiration
        };
    }

    private async Task<IEnumerable<Claim>> GetClaims(User user, List<string> audiences)//buradaki audience bu jwt tokena istek atabilecek projeleri listelerken kullanılır
    {
        var userList = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, user.Id),
            new Claim(JwtRegisteredClaimNames.Email,user.Email),
            new Claim(ClaimTypes.Name, user.UserName),
        };

        var roles = await _userManager.GetRolesAsync(user);
        if (roles.Count > 0)
        {
            userList.AddRange(roles.Select(x => new Claim(ClaimTypes.Role, x)));
        }

        userList.AddRange(audiences.Select(x => new Claim(JwtRegisteredClaimNames.Aud, x)));

        return userList;
    }
}
