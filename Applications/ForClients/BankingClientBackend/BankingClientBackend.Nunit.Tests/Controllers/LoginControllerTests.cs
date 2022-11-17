using BankingClientBackend.Controllers;
using BankingClientBackend.EnviromentConfigs;
using BankingClientBackend.Services.Middlewares.JWT;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Moq;

namespace BankingClientBackend.Nunit.Tests.Controllers;

public class LoginControllerTests
{
    private Mock<IUserService> _mockRepo;
    private IUserService _userService;
    private LoginController _controller;
    
    public static AppSettings GetConfig()
    {
        //var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
        var environment = "Development";
        var myjson = $"../appsettings.{environment}.json";
        var currentDirectory = Directory.GetCurrentDirectory();
        myjson = myjson.Replace("..", ".");
        // check if file exists
        var file = Path.Combine(currentDirectory, myjson);
        if (!File.Exists(file))
        {
            throw new FileNotFoundException($"The configuration file '{file}' was not found and is not optional.");
        }
        // read file into string
        var json = File.ReadAllText(file);

        var configV0 = new ConfigurationBuilder();
        
        configV0.AddJsonFile(file, optional: false, reloadOnChange: true);
        
        var configs = configV0.Build().GetSection("AppSettings");
        
        
        
        var config = new ConfigurationBuilder()
            .AddJsonFile(file, optional: false)
            .Build().GetSection("AppSettings").Get<AppSettings>();
        return config;
    }
    
    [SetUp]
    public void Setup()
    {
        _mockRepo = new Mock<IUserService>();
        
        IOptions<AppSettings> someOptions = Options.Create<AppSettings>(GetConfig());
        _userService = new UserService(someOptions);
        _controller = new LoginController(_userService);
    }

    [Test]
    public void Test1()
    {
        var user =new AuthenticateRequest { Username = "test", Password = "test" };
        _mockRepo.Setup(p => p.Authenticate(user));

        var result = _controller.Authenticate(new AuthenticateRequest { Username = "test", Password = "test" });
        
        Assert.That(result, Is.TypeOf<OkObjectResult>());
    }
}