using Microsoft.AspNetCore.Mvc;
using ApiProject.Models;

namespace ApiProject.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DatabaseController : ControllerBase
{
    private readonly TasksContext dbcontext;

    public DatabaseController(TasksContext dbcontext)
    {
        this.dbcontext = dbcontext;
    }

    [HttpGet]
    [Route("createdb")]
    public IActionResult CreateDatabase()
    {
        dbcontext.Database.EnsureCreated();
        return Ok();
    }
}

