using BankingDataAccess.Core.BaseDomain;

namespace BankingDataAccess.Core.Domain;

public class Users: Entity
{
    public Users()
    {
        DirectlyAssignTokensTokens = new HashSet<Tokens>();
        Roles = new HashSet<Roles>();
    }
    
    public virtual ICollection<Tokens> DirectlyAssignTokensTokens { get; set; }
    public virtual ICollection<Roles> Roles { get; set; }
    
    public string UserName { get; set; }
    public string Password { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    public string EmployeeId { get; set; }
    public bool IsActive { get; set; }
}
/*
public class UserClaims: Entity
{
    public int UserId { get; set; }
    public string ClaimType { get; set; }
    public string ClaimValue { get; set; }
}

public class UserLogins: Entity
{
    public int UserId { get; set; }
    public string LoginProvider { get; set; }
    public string ProviderKey { get; set; }
}

public class UserTokens: Entity
{
    public int UserId { get; set; }
    public string LoginProvider { get; set; }
    public string Name { get; set; }
    public string Value { get; set; }
}

public class Deparments: Entity
{
    public string DepartmentName { get; set; }
    public string Description { get; set; }
}

public class Employees: Entity
{
    public string EmployeeName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
}

public class EmployeeDeparments: Entity
{
    public int EmployeeId { get; set; }
    public int DepartmentId { get; set; }
}

// Users to Employees
public class UserEmployees: Entity
{
    public int UserId { get; set; }
    public int EmployeeId { get; set; }
}
*/