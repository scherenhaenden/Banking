using BankingClientBackend.Services.Middlewares.JWT;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace BankingClientBackend.Controllers;


[ApiController]
[Route("[controller]")]
public class LoginController : Controller
{
    private IUserService _userService;
    private readonly JwtTokenGenerator _jwtTokenGenerator;

    public LoginController(IUserService userService, JwtTokenGenerator jwtTokenGenerator)
    {
        _userService = userService;
        _jwtTokenGenerator = jwtTokenGenerator;
    }
    
    
    // Create method of http type get and allow anonymous and route login employees that accepts a string EmployeeId and string Password
    [AllowAnonymous]
    [HttpGet("LoginEmployees")]
    public IActionResult LoginEmployees(string EmployeeId, string Password)
    {
        // Create a variable of type user and assign it to the result of the method login of the user service
        /*var user = _userService.Login(EmployeeId, Password);
        // If the user is null
        if (user == null)
        {
            // Return a bad request
            return BadRequest(new { message = "Username or password is incorrect" });
        }
        // Return the user
        return Ok(user);*/
        
        // Create a http client  to make rest calls
        HttpClient client = new HttpClient();
        // Create a string variable and assign it to the base url of the api
        string baseUrl = "http://localhost:60001/Login/LoginEmployee";
        // Create a string variable and assign it to the url of the api
        string url = baseUrl + "?EmployeeId=" + EmployeeId + "&Password=" + Password;
        // Create a string variable and assign it to the result of the get async method of the client
        string result = client.GetAsync(url).Result.Content.ReadAsStringAsync().Result;
        
        // Parse string json to object
        var user = JsonConvert.DeserializeObject<GenericFrontEndUser>(result);
        
        // Create generic response
        var genericAuthenticateResponse = new GenericAuthenticateResponse(user, _jwtTokenGenerator.GenerateToken(user.Id.ToString(), new List<string>(), new List<string>()) );
        
        
        
        if (HttpContext != null)
        {
            HttpContext.Response.Headers.Add("Authorization", "Bearer " + genericAuthenticateResponse.Token);
        }
        
        
        // Return the result
        return Ok(genericAuthenticateResponse);
        
        
        // Create call to rest microservice
        //var client = new RestClient("http://localhost:5000/api/employees");
    }
    
    
    
    
    

    [AllowAnonymous]
    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest model)
    {
        var response = _userService.Authenticate(model);

        // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
        if (response == null)
        {
            return BadRequest(new { message = "Username or password is incorrect" });
        }

        try
        {
            // ReSharper disable once ConditionIsAlwaysTrueOrFalseAccordingToNullableAPIContract
            if (HttpContext != null)
            {
                HttpContext.Response.Headers.Add("Authorization", "Bearer " + response.Token);
            }

        }
        catch (Exception e)
        {
            return BadRequest(new { message = "An error just ocurred" });
        }
       
        return Ok(response);
    }

    [Services.Middlewares.JWT.Authorize]
    [HttpGet]
    public IActionResult GetAll()
    {
        var users = _userService.GetAll();
        return Ok(users);
    }
}