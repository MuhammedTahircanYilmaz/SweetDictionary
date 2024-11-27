using SweetDictionary.Models.Roles.Dtos;

namespace SweetDictionary.Service.Roles.Services.Abstracts;

public interface IRoleService
{

    Task<string> AddRoleToUser(AddRoleToUserRequestDto dto);

    Task<List<string>> GetAllRolesByUserId(string userId);

    Task<string> AddRoleAsync(string name);
}