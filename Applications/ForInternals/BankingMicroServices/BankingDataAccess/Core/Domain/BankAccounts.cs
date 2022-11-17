using BankingDataAccess.Core.BaseDomain;

namespace BankingDataAccess.Core.Domain;

public class BankAccounts: Entity
{
    public BankAccounts()
    {
        Transactions = new HashSet<Transactions>();
    }
    
    public virtual ICollection<Transactions> Transactions { get; set; }
    
    public string Iban { get; set; }
    public virtual AccountTypes AccountType { get; set; }
    public decimal Balance { get; set; }
    public bool IsActive { get; set; }
    public virtual Currency Currency { get; set; }
}