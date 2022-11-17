using AutoMapper;
using BankingClientBackend.Services.Middlewares.JWT;
using Microsoft.AspNetCore.Mvc;

namespace BankingClientBackend.Controllers;

[Services.Middlewares.JWT.Authorize]
[ApiController]
[Route("[controller]")]
public class AccountsController : Controller
{

    public List<BankingAccountComplete> AccountsFortest => GetMockData();
    
    public AccountsController()
    {
    }
    
    
    [HttpGet("GetAccounts")]
    public List<BankingAccountSimple> GetAccounts()
    {
        
        var user = GetCurrentUser();
        
        var config = new MapperConfiguration(cfg => 
            {
                cfg.AllowNullCollections = true;
                cfg.CreateMap<BankingAccountComplete, BankingAccountSimple>();
            }
            );
        var mapper = new Mapper(config);
        var destinations = mapper.Map<List<BankingAccountComplete>, List<BankingAccountSimple>>(AccountsFortest);

        return destinations;
    }

    private User? GetCurrentUser()
    {
       
        
        var user = (User)HttpContext.Items["User"];

        return user;
    }


    [HttpGet("GetAccountCompactByIserIdAndAccountNumber")]
    
    public BankingAccountComplete? GetAccountCompactByIserIdAndAccountNumber(string userId, string userAccountNumber)
    {
        var result = AccountsFortest.FirstOrDefault(x=>x.AccountId == userAccountNumber);
        
        return result;
    }

    // Create Private method with mockData for testing BankAccount Complete
    private List<BankingAccountComplete> GetMockData()
    {

        var bankingAccountComplete1 = new BankingAccountComplete();
        bankingAccountComplete1.UserId = "1";
        bankingAccountComplete1.AccountId = "1";
        bankingAccountComplete1.Name = "Test1";
        bankingAccountComplete1.Balance = 1000;
        bankingAccountComplete1.Currency = "EUR";
        bankingAccountComplete1.IsCurrencyTypeCode = "EUR";
        bankingAccountComplete1.Iban = "DE1234567890";
        bankingAccountComplete1.Bic = "DEUTDEFF";
        bankingAccountComplete1.Type = "Savings";
        bankingAccountComplete1.Status = "Active";
        bankingAccountComplete1.CreatedAt = DateTime.Now;
        bankingAccountComplete1.UpdatedAt = DateTime.Now;
        bankingAccountComplete1.IsDefault = true;
        bankingAccountComplete1.IsArchived = false;
        bankingAccountComplete1.IsDeleted = false;
        bankingAccountComplete1.IsLocked = false;
        bankingAccountComplete1.IsVerified = true;
        bankingAccountComplete1.IsVerifiedBy = "1";
        bankingAccountComplete1.VerifiedAt = DateTime.Now;
        
        var bankingAccountComplete2 = new BankingAccountComplete();
        bankingAccountComplete2.UserId = "1";
        bankingAccountComplete2.AccountId = "2";
        bankingAccountComplete2.Name = "Test2";
        bankingAccountComplete2.Balance = 2000;
        bankingAccountComplete2.Currency = "EUR";
        bankingAccountComplete2.IsCurrencyTypeCode = "EUR";
        bankingAccountComplete2.Iban = "DE1234567891";
        bankingAccountComplete2.Bic = "DEUTDEFF";
        bankingAccountComplete2.Type = "Savings";
        bankingAccountComplete2.Status = "Active";
        bankingAccountComplete2.CreatedAt = DateTime.Now;
        bankingAccountComplete2.UpdatedAt = DateTime.Now;
        bankingAccountComplete2.IsDefault = true;
        bankingAccountComplete2.IsArchived = false;
        bankingAccountComplete2.IsDeleted = false;
        bankingAccountComplete2.IsLocked = false;
        bankingAccountComplete2.IsVerified = true;
        bankingAccountComplete2.IsVerifiedBy = "1";
        bankingAccountComplete2.VerifiedAt = DateTime.Now;
        
        var bankingAccountComplete3 = new BankingAccountComplete();
        bankingAccountComplete3.UserId = "1";
        bankingAccountComplete3.AccountId = "3";
        bankingAccountComplete3.Name = "Test3";
        bankingAccountComplete3.Balance = 3000;
        bankingAccountComplete3.Currency = "EUR";
        bankingAccountComplete3.IsCurrencyTypeCode = "EUR";
        bankingAccountComplete3.Iban = "DE1234567892";
        bankingAccountComplete3.Bic = "DEUTDEFF";
        bankingAccountComplete3.Type = "Savings";
        bankingAccountComplete3.Status = "Active";
        bankingAccountComplete3.CreatedAt = DateTime.Now;
        bankingAccountComplete3.UpdatedAt = DateTime.Now;
        bankingAccountComplete3.IsDefault = true;
        bankingAccountComplete3.IsArchived = false;
        bankingAccountComplete3.IsDeleted = false;
        bankingAccountComplete3.IsLocked = false;
        bankingAccountComplete3.IsVerified = true;
        bankingAccountComplete3.IsVerifiedBy = "1";
        bankingAccountComplete3.VerifiedAt = DateTime.Now;
        
        
        
        
        
        
        
        
        return new List<BankingAccountComplete>()
        {
            {bankingAccountComplete1},  {bankingAccountComplete2}, {bankingAccountComplete3} 
        };
    }
}

public class BankingAccountSimple
{
    public string UserId { get; set; } = null!;
    public string AccountId { get; set; } = null!;
    public string Name { get; set; } = null!;
    public int Balance { get; set; }
    public string Currency { get; set; } = null!;
    public bool IsDefault { get; set; }
    public bool IsArchived { get; set; }
    public string IsCurrencyTypeCode { get; set; } = null!;
    public bool IsDeleted { get; set; }
    
    public string Type { get; set; }
}

public class BankingAccountComplete: BankingAccountSimple
{
    
    public List<Transaction>? Transactions { get; set; }
    public string Iban { get; set; }
    public string Bic { get; set; }
    public string Status { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public bool IsLocked { get; set; }
    public bool IsVerified { get; set; }
    public string IsVerifiedBy { get; set; }
    public DateTime VerifiedAt { get; set; }
}

public class Transaction
{
    public string Id { get; set; }
    public DateTime Date { get; set; }
    public string? Description { get; set; }
    public int Amount { get; set; }
    public string Currency { get; set; } = null!;
    public string Type { get; set; } = null!;
    public bool IsBlocked { get; set; }
    public string RelatedTransactionAccountNumber { get; set; } = null!;
}