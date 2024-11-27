using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Tokens.Dtos;

namespace SweetDictionary.Service.Tokens.Services.Abstracts;

public interface IJwtService
{
    Task<TokenResponseDto> CreateToken(User user);
}

