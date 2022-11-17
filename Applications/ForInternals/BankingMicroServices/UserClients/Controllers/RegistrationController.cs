using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserClients.BusinessLogic.Core.Registration;
using UserClients.BusinessLogic.Models.RegistrationDomain;

namespace UserClients.Controllers;

[ApiController]
[Route("[controller]")]
public class RegistrationController : Controller
{
    private readonly IRegistrationLogicService _registrationLogicService;

    public RegistrationController(
        IRegistrationLogicService registrationLogicService)
    {
        _registrationLogicService = registrationLogicService;
    }
    
    
    [AllowAnonymous]
    [HttpPost]
    [Route("Register")]
    public async Task<IActionResult> Register([FromBody] UserRegistrationModelBusinessLogic request)
    {
        var result = await _registrationLogicService.TryRegistration(request, out var resultObject);
        return Ok(resultObject);
    }
    /*private readonly UserManager<IdentityUser> _userManager;
    private readonly SignInManager<IdentityUser> _signInManager;

    public RegistrationController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
    {
        _userManager = userManager;
        _signInManager = signInManager;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Register(RegisterViewModel model)
    {
        if (ModelState.IsValid)
        {
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(user, isPersistent: false);
                return RedirectToAction("Index", "Home");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }

        return View("Index", model);
    }*/
}
