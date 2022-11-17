using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternalUsers.Controllers;

[ApiController]
[Route("[controller]")]
public class TokensController : Controller
{
    [AllowAnonymous]
    [HttpPost]
    [Route("AddToken")]
    public IActionResult Index()
    {
        return Ok();
    }
}