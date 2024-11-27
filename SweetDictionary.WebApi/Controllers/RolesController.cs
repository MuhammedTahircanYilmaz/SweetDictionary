using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Roles.Dtos;
using SweetDictionary.Service.Roles.Services.Abstracts;

namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize(Roles = "Admin")]
public class RolesController(IRoleService roleService) : ControllerBase
{

    [HttpPost("addroletouser")]
    public async Task<IActionResult> AddRoleToUser([FromBody] AddRoleToUserRequestDto dto)
    {
        var result = await roleService.AddRoleToUser(dto);
        return Ok(result);
    }

    [HttpGet("getallrolesbyid")]
    public async Task<IActionResult> GetAllRolesByUserId([FromQuery] string userId)
    {
        var result = await roleService.GetAllRolesByUserId(userId);
        return Ok(result);
    }

    [HttpPost("addrole")]
    public async Task<IActionResult> AddRoleAsync([FromQuery] string Name)
    {
        var result = await roleService.AddRoleAsync(Name);
        return Ok(result);
    }

}