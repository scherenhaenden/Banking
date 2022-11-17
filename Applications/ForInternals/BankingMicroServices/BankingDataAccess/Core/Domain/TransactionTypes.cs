using BankingDataAccess.Core.BaseDomain;

namespace BankingDataAccess.Core.Domain;

public class TransactionTypes: Entity
{
    public string TransactionType { get; set; }
}