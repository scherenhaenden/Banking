using BankingDataAccess.Core.BaseDomain;

namespace BankingDataAccess.Core.Domain;

public class Customer: Entity
{
    public Customer()
    {
        Account = new HashSet<BankAccounts>();
        Addresses = new HashSet<Addresses>();
    }
    
    public virtual ICollection<BankAccounts> Account { get; set; }
    public virtual ICollection<Addresses> Addresses { get; set; }
    
    
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


