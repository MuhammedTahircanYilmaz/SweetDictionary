using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using SweetDictionary.Models.Users.Dtos.Requests;
using SweetDictionary.Service.Authentications.Services.Abstracts;

namespace SweetDictionary.WebApi.Controllers
{
    [Route("api/Users/")]
    [ApiController]
    public class AuthenticationController(IAuthenticationService _authenticationService) : ControllerBase
    {

        [HttpPost("register")]
        public async Task<IActionResult> CreateUser([FromBody] RegisterRequestDto dto)
        {
            var result = await _authenticationService.RegisterByTokenAsync(dto);

            return Ok(result);
        }


        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDto dto)
        {
            var result = await _authenticationService.LoginByTokenAsync(dto);
            return Ok(result);
        }
    }
}
