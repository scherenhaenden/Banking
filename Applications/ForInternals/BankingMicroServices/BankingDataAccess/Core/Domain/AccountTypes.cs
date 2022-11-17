using BankingDataAccess.Core.BaseDomain;

namespace BankingDataAccess.Core.Domain;

public class AccountTypes: Entity
{
    public string AccountType { get; set; }
}