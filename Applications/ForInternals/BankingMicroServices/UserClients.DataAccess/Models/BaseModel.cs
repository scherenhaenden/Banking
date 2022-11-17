namespace UserClients.DataAccess.Models;

public class BaseModel
{
    public Guid Id { get; set; }
    
    public DateTime CreatedDateTime { get; set; }
    
    public DateTime? ModifiedDateTime { get; set; }
}