using BankingDataAccess.Core.BaseDomain;

namespace BankingDataAccess.Core.Domain;

public class Currency: Entity
{
    public string Name { get; set; }
    public string Code { get; set; }
    public string Symbol { get; set; }
}