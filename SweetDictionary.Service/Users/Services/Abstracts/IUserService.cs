using Core.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Users.Dtos.Requests;
using SweetDictionary.Models.Users.Dtos.Response;

namespace SweetDictionary.Service.Users.Services.Abstracts;

public interface IUserService
{
    Task<User> RegisterUserAsync(RegisterRequestDto registerRequestDto);
    Task<User> LoginAsync(LoginRequestDto dto);
    Task<ReturnModel<NoData>> UpdateAsync(string id, UpdateUserRequestDto dto);
    Task<ReturnModel<NoData>> DeleteAsync(string id);
    Task<ReturnModel<UserResponseDto>> GetByEmailAsync(string email);
    Task<ReturnModel<NoData>> ChangePasswordAsync(string userId, ChangePasswordRequestDto dto);

}
