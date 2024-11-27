using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Comments.Dtos.Requests;
using SweetDictionary.Service.Comments.Services.Abstracts;
using System.Security.Claims;

namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CommentsController(ICommentService _commentService) : ControllerBase
{

    [HttpPost("add")]
    public IActionResult Add([FromBody] AddCommentRequestDto dto)
    {
        string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var result = _commentService.Add(dto, userId);
        return Ok(result);
    }

    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdateCommentRequestDto dto)
    {
        string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var result = _commentService.Update(dto, userId);
        return Ok(result);
    }
    [HttpDelete("delete")]
    public IActionResult Delete([FromBody] Guid id)
    {
        string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var result = _commentService.Delete(id, userId);
        return Ok(result);
    }

    [HttpGet("all")]
    public IActionResult GetAll()
    {
        var result = _commentService.GetAll();
        return Ok(result);
    }

    [HttpGet("byid/{id:long}")] // : koyup tip belirtmesi yapabiliyorsun
    public IActionResult GetById([FromRoute] Guid id)
    {
        var result = _commentService.GetById(id);
        return Ok(result);
    }

    [HttpGet("byuserid")]
    public IActionResult GetAllByUserId()
    {
        string userId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier).Value;
        var result = _commentService.GetAllByUserId(userId);
        return Ok(result);
    }

    [HttpGet("bypostid")]
    public IActionResult GetAllByPostId([FromRoute]Guid postId)
    {
        var result = _commentService.GetAllByPostId(postId);
        return Ok(result);
    }
}
