using Microsoft.AspNetCore.Mvc;

namespace BankingClientBackend.Controllers;

    [ApiController]
    [Route("[controller]")]
public class MainDashBoard : Controller
{
    [HttpGet]
    public IActionResult Get()
    {
        return Ok("Hello World");
    }
}