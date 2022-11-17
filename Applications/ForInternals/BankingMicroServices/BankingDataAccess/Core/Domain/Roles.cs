using BankingDataAccess.Core.BaseDomain;

namespace BankingDataAccess.Core.Domain;

public class Roles: Entity
{
    public Roles()
    {
        Tokens = new HashSet<Tokens>();
        Users = new HashSet<Users>();
    }
    
    public virtual ICollection<Tokens> Tokens { get; set; }
    public virtual ICollection<Users> Users { get; set; }

    public string RoleName { get; set; }
    public string Description { get; set; }
    public bool IsActive { get; set; }
}