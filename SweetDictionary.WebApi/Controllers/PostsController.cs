using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Posts.Dtos.Requests;
using SweetDictionary.Service.Posts.Services.Abstracts;
using System.Security.Claims;

namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PostsController(IPostService _postService) : ControllerBase
{

    [HttpGet("all")]
    public IActionResult GetAll()
    {
        var result = _postService.GetAll();
        return Ok(result);
    }

    [HttpPost("add")]
    public IActionResult Add([FromBody]CreatePostRequestDto dto)
    {
        string authorId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

        var result = _postService.Add(dto, authorId);
        return Ok(result);
    }

    [HttpGet("postbyid/{id:guid}")] // : koyup tip belirtmesi yapabiliyorsun
    public IActionResult GetById([FromRoute] Guid id)
    {
        var result = _postService.GetById(id);
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdatePostRequestDto dto)
    {
        string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

        var result = _postService.Update(dto, userId);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public IActionResult Delete([FromBody] Guid id)
    {
        string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;

        var result = _postService.Delete(id, userId);
        return Ok(result);
    }

}
