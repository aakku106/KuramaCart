using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Controllers;

[ApiController]
[Route("[controller]")]
public class ErrorController : ControllerBase
{
    [HttpGet]
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem("An error occurred.");
    }
}