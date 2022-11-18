using BankingDataAccess.Core.BaseDomain;
using BankingDataAccess.Core.Configuration;
using BankingDataAccess.Core.Domain;
using GenericTools.Mapping;
using GenericTools.Security.Core;
using GenericTools.Security.Persistance;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Customers.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomerController : Controller
{
   private readonly IUnitOfWorkV2 _unitOfWork;

   // Add constructor to inject the service IUnitOfWorkV2
   public CustomerController(IUnitOfWorkV2 unitOfWork)
   {
      _unitOfWork = unitOfWork;
   }
   
   // add method to log customer in and it should be a POST method that returns a token header and a user object and allow anonymous
   [HttpPost("login")]
   [AllowAnonymous]
   public async Task<IActionResult> Login([FromBody] LoginModel model)
   {
      ISimpleEncryptionService encryptionService = new SimpleEncryptionServiceMd5();
      
      var password = encryptionService.EncryptValue(model.Password);
      
      var customer = await _unitOfWork.Customers.Where(customer => customer.Email == model.Email && customer.Passport == password).FirstOrDefaultAsync();
      if (customer == null)
         return BadRequest(new { message = "Username or password is incorrect" });
      return Ok(customer);
   }
   
   // add method to register a customer and it should be a POST method that returns a token header and a user object and allow anonymous
   [HttpPost("register")]
   [AllowAnonymous]
   public async Task<IActionResult> Register([FromBody] RegisterModel model)
   {
      ISimpleEncryptionService encryptionService = new SimpleEncryptionServiceMd5();
      
      var password = encryptionService.EncryptValue(model.Password);
      
      
      
      IMappingViaJson mappingViaJson = new MappingViaJson();
      var userObject =mappingViaJson.Map<Customer>(model);
      
      userObject.Password = password;
      
      userObject.Addresses.ToList().ForEach(i=>i.IsNew());
      userObject.IsNew();
      
      
      
      _unitOfWork.Addresses.AddRange(userObject.Addresses.ToList());
      _unitOfWork.Customers.Add(userObject);
      _unitOfWork.Complete();
      
      model =mappingViaJson.Map<RegisterModel>(userObject);
      
      return Ok(model);
   }
}

public class LoginModel
{
   public string Email { get; set; }
   public string Password { get; set; }
}

public class RegisterModel
{
   public List<AddressesApiModel> Addresses { get; set; }
   
   public DateTime DateOfSignup { get; set; }
   public string TypeOfCustomer { get; set; } = null!;
   public DateTime DateOfBirth { get; set; }
   public string FirstName { get; set; }
   public string LastName { get; set; }
   public string PhoneNumber { get; set; }
   public string Email { get; set; }
   public string Password { get; set; }
   public string Passport { get; set; }
   public string NationalId { get; set; }
}

public class AddressesApiModel
{
   public string Country { get; set; }
   public string City { get; set; }
   public string Street { get; set; }
   public string PostalCode { get; set; }
   public string HouseNumber { get; set; }
   public string ApartmentNumber { get; set; }
   public string ExtraInformation { get; set; }
}
