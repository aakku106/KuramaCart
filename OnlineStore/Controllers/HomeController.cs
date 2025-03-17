using Microsoft.AspNetCore.Mvc;

namespace OnlineStore.Controllers;

[ApiController]
public class HomeController : ControllerBase
{
    [HttpGet("/")]
    public IActionResult Index()
    {
        return Ok(new
        {
            message = "OnlineStore API is running",
            endpoints = new[] {
                "/api/products",
                "/api/products/beauty",
                "/api/products/kitchen",
                "/api/cart/beauty",
                "/api/cart/kitchen",
                "/api/auth/login"
            }
        });
    }
}