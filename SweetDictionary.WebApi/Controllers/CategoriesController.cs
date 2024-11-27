using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Categories.Dtos.Requests;
using SweetDictionary.Service.Categories.Services.Abstracts;

namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class CategoriesController(ICategoryService _categoryService) : ControllerBase
{

    [HttpPost("add")]
    [Authorize(Roles = "Admin")]
    public IActionResult Add([FromBody] AddCategoryRequestDto dto)
    {
        var result = _categoryService.Add(dto);
        return Ok(result);
    }
   
    [HttpPut("update")]
    [Authorize(Roles = "Admin")]

    public IActionResult Update([FromBody] UpdateCategoryRequestDto dto)
    {
        var result = _categoryService.Update(dto);
        return Ok(result);
    }
    [HttpDelete("delete")]
    [Authorize(Roles = "Admin")]

    public IActionResult Delete([FromBody] int id)
    {
        var result = _categoryService.Delete(id);
        return Ok(result);
    }

    [HttpGet("all")]
    public IActionResult GetAll()
    {
        var result = _categoryService.GetAll();
        return Ok(result);
    }

    [HttpGet("byid/{id:int}")] // : koyup tip belirtmesi yapabiliyorsun
    public IActionResult GetById([FromRoute] int id)
    {
        var result = _categoryService.GetById(id);
        return Ok(result);
    }
}
