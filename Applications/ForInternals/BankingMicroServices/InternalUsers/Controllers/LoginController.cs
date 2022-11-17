using InternalUsers.BusinessLogic.Core;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternalUsers.Controllers;

[ApiController]
[Route("[controller]")]
public class LoginController : Controller
{
    private readonly ILogicBusinessLogic _logicBusinessLogic;

    public LoginController(ILogicBusinessLogic logicBusinessLogic)
    {
        _logicBusinessLogic = logicBusinessLogic;
    }

    // Create Method of http type get, allow anonymous route 'LoginEmployee' and accepts the parameters 'EmployeeId' and 'Password'
    [AllowAnonymous]
    [HttpGet]
    [Route("LoginEmployee")]
    public IActionResult LoginEmployee(string EmployeeId, string Password)
    {
        var user = _logicBusinessLogic.GetUserInformationByEmployeeIdAndPassword(EmployeeId, Password);
        if (user == null)
        {
            return Unauthorized();
        }
        return Ok(user);
    }
    
    // Create Method of http type get, allow anonymous route 'LoginCustomer' and accepts the parameters 'Email' and 'Password' 
    // This method will be migrated to another service called UserClients
    [AllowAnonymous]
    [HttpGet]
    [Route("LoginCustomer")]
    public IActionResult LoginCustomer(string Email, string Password)
    {
        var user = _logicBusinessLogic.GetCustomerInformationByEmailAndPassword(Email, Password);
        if (user == null)
        {
            return Unauthorized();
        }
        return Ok(user);
    }
}