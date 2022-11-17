namespace InternalUsers.DataAccess.Database.Models.Login;

public class UserDatabaseOutput
{
    public List<DirectlyAssignTokensTokenDataBaseOutput> DirectlyAssignTokensTokens { get; set; }
    public List<RoleDataBaseOutput> Roles { get; set; }
    public string UserName { get; set; }
    public string Email { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string EmployeeId { get; set; }
    public bool IsActive { get; set; }
    public Guid Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? ModifiedDateTime { get; set; }
}

public class RoleDataBaseOutput
{
    public List<TokenDataBaseOutput> tokens { get; set; }
    public string roleName { get; set; }
    public bool isActive { get; set; }
    public string id { get; set; }
    public DateTime createdDateTime { get; set; }
    public DateTime? modifiedDateTime { get; set; }
}

public class TokenDataBaseOutput
{
    public List<object> roles { get; set; }
    public string token { get; set; }
    public object expiryDate { get; set; }
    public string tokenName { get; set; }
    public string description { get; set; }
    public bool isActive { get; set; }
    public string id { get; set; }
    public DateTime createdDateTime { get; set; }
    public object modifiedDateTime { get; set; }
}

public class DirectlyAssignTokensTokenDataBaseOutput
{
    public string token { get; set; }
    public object expiryDate { get; set; }
    public string tokenName { get; set; }
    public string description { get; set; }
    public bool isActive { get; set; }
    public string id { get; set; }
    public DateTime createdDateTime { get; set; }
    public object modifiedDateTime { get; set; }
}

