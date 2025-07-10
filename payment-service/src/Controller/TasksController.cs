namespace payment_service.Controller;

using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/payment")]
public class TasksController : ControllerBase
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok(new[] { "Payment 1", "Payment 2" });
    }
}