namespace user_service.Controllers;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/tasks")]
public class TasksController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new[] { "Task 1", "Task 2" });
    }
}