using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json.Serialization;
using BankingClientBackend.EnviromentConfigs;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace BankingClientBackend.Services.Middlewares.JWT;

public class User
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }

    [JsonIgnore]
    public string Password { get; set; }
}

public class GenericFrontEndUser
{
    public Guid Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string EmployeeId { get; set; }
    public Object Roles { get; set; }
    public Object serviceTokens { get; set; }

    [JsonIgnore]
    public string Password { get; set; }
}

public class GenericAuthenticateResponse
{
    public   GenericAuthenticateResponse(GenericFrontEndUser user, string jwtToken)
    {
        User = user;
        Token = jwtToken;
    }
    
    GenericFrontEndUser User { get; set; }
    
    public string Token { get; set; }

}







public class AuthenticateResponse
{
    public int Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Token { get; set; }


    public AuthenticateResponse(User user, string token)
    {
        Id = user.Id;
        FirstName = user.FirstName;
        LastName = user.LastName;
        Username = user.Username;
        Token = token;
    }
}

public interface IUserService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IEnumerable<User> GetAll();
    User GetById(int id);
}
public class AuthenticateRequest
{
    [Required]
    public string Username { get; set; }

    [Required]
    public string Password { get; set; }
}

public class UserService : IUserService
{
    // users hardcoded for simplicity, store in a db with hashed passwords in production applications
    private List<User> _users = new List<User>
    {
        new User { Id = 1, FirstName = "Test", LastName = "User", Username = "test", Password = "test" }
    };

    private readonly AppSettings _appSettings;

    public UserService(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

        // return null if user not found
        if (user == null) return null;

        // authentication successful so generate jwt token
        var token = generateJwtToken(user);

        return new AuthenticateResponse(user, token);
    }

    public IEnumerable<User> GetAll()
    {
        return _users;
    }

    public User GetById(int id)
    {
        return _users.FirstOrDefault(x => x.Id == id);
    }

    // helper methods

    private string generateJwtToken(User user)
    {
        // generate token that is valid for 7 days
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.SecretJwtKey);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}

public class JwtTokenGenerator  
{  
    private readonly AppSettings _appSettings;  
    public JwtTokenGenerator(IOptions<AppSettings> appSettings)  
    {  
        _appSettings = appSettings.Value;  
    }  
    public string GenerateToken(string userId, List<string>? userRoles, List<string>? userServiceTokens)
    {
        List<Claim> RoleClaims = new List<Claim>();  
        

        // Parse user roles to claims
        foreach (var role in userRoles)
        {
            var claim = new Claim(ClaimTypes.Role, role);
            RoleClaims.Add(claim);
        }
        
        // Parse user tokens to claims
        foreach (var serviceToken in userServiceTokens)
        {
            var claim = new Claim(ClaimTypes.UserData, serviceToken);
            RoleClaims.Add(claim);
        }
     
        
        RoleClaims.Add(new Claim(ClaimTypes.NameIdentifier, userId));
        
        var tokenHandler = new JwtSecurityTokenHandler();  
        var key = Encoding.ASCII.GetBytes(_appSettings.SecretJwtKey);  
        var tokenDescriptor = new SecurityTokenDescriptor  
        {  
            Subject = new ClaimsIdentity(
                RoleClaims),
            Expires = DateTime.UtcNow.AddHours(1),  
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)  
        };  
        var token = tokenHandler.CreateToken(tokenDescriptor);  
        return tokenHandler.WriteToken(token);  
    }  
}



public class JwtMiddleware
{
    // Create JWT As Middleware service
    private readonly RequestDelegate _next;
    private readonly AppSettings _appSettings;

    public JwtMiddleware(RequestDelegate next, IOptions<AppSettings> appSettings)
    {
        _next = next;
        _appSettings = appSettings.Value;
    }

    public async Task Invoke(HttpContext context, IUserService userService)
    {
        var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();

        if (token != null)
            attachUserToContext(context, userService, token);

        await _next(context);
    }

    private void attachUserToContext(HttpContext context, IUserService userService, string token)
    {
        try
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecretJwtKey);
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                // set clockskew to zero so tokens expire exactly at token expiration time (instead of 5 minutes later)
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);

            var jwtToken = (JwtSecurityToken)validatedToken;
            var userId = int.Parse(jwtToken.Claims.First(x => x.Type == "id").Value);

            // attach user to context on successful jwt validation
            context.Items["User"] = userService.GetById(userId);
        }
        catch
        {
            // do nothing if jwt validation fails
            // user is not attached to context so request won't have access to secure routes
        }
    }
    
    
}