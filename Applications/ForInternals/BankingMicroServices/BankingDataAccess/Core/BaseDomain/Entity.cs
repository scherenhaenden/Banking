namespace BankingDataAccess.Core.BaseDomain;

public class Entity : IEntity
{

    public Entity(bool isNew = false)
    {
        if (isNew)
        {
            Id = Guid.NewGuid();
            CreatedDateTime = DateTime.Now;
        }
    }
    public Guid Id { get; set; }
    
    public DateTime CreatedDateTime { get; set; }
    
    public DateTime? ModifiedDateTime { get; set; }
}


public static class EntityExtensions
{
    public static void IsNew(this Entity entity)
    {
        entity.Id = Guid.NewGuid();
        entity.CreatedDateTime = DateTime.Now;
    }
}