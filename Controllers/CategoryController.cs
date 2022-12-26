using Microsoft.AspNetCore.Mvc;
using ApiProject.Models;
using ApiProject.Services;

namespace ApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    ICategoryService categoryService;


    public CategoryController(ICategoryService service)
    {
        categoryService = service;

    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(categoryService.Get());
    }


    [HttpPost]
    public IActionResult Post([FromBody] Category categoria)
    {
        categoryService.Save(categoria);
        return Ok();
    }


    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Category categoria)
    {
        categoryService.Update(id, categoria);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        categoryService.Delete(id);
        return Ok();
    }
}