using Microsoft.AspNetCore.Mvc;
using ApiProject.Models;
using ApiProject.Services;
using Task = ApiProject.Models.Task;

namespace ApiProject.Controllers;

[Route("api/[controller]")]
public class TaskController : ControllerBase
{
    ITaskService tareasService;

    public TaskController(ITaskService service)
    {
        tareasService = service;
    }

    [HttpGet]
    public IActionResult Get()
    {
        return Ok(tareasService.Get());
    }

    
    [HttpPost]
    public IActionResult Post([FromBody] Task task)
    {
        tareasService.Save(task);
        return Ok();
    }


    [HttpPut("{id}")]
    public IActionResult Put(Guid id, [FromBody] Task task)
    {
        tareasService.Update(id, task);
        return Ok();
    }

    [HttpDelete("{id}")]
    public IActionResult Delete(Guid id)
    {
        tareasService.Delete(id);
        return Ok();
    }    
}