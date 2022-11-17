namespace BankingDataAccess.Core.BaseDomain;

public interface IEntity
{
    Guid Id { get; set; }
    
    DateTime CreatedDateTime { get; set; }
    
    DateTime? ModifiedDateTime { get; set; }
}