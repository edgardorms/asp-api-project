using Microsoft.AspNetCore.Mvc;
using ApiProject.Models;
using ApiProject.Services;

namespace ApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    ICategoryService categoryService;
    TasksContext dbcontext;


    public CategoryController(ICategoryService service, TasksContext db)
    {
        categoryService = service;
        dbcontext = db;

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


    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();

        return Ok();

    }
}