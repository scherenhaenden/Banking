using BankingDataAccess.Core.BaseDomain;

namespace BankingDataAccess.Core.Domain;

public class Tokens: Entity
{
    public Tokens()
    {
        Users = new HashSet<Users>();
        Roles = new HashSet<Roles>();
    }
    
    public virtual ICollection<Users> Users { get; set; }
    public virtual ICollection<Roles> Roles { get; set; }
    public string Token { get; set; }
    public DateTime? ExpiryDate { get; set; }
    public string? TokenName { get; set; }
    public string? Description { get; set; }
    public bool IsActive { get; set; }
}