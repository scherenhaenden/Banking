using BankingDataAccess.Core.BaseDomain;

namespace BankingDataAccess.Core.Domain;

public class Addresses: Entity
{
    public virtual Customer Customer { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public string HouseNumber { get; set; }
    public string ApartmentNumber { get; set; }
    public string ExtraInformation { get; set; }
}