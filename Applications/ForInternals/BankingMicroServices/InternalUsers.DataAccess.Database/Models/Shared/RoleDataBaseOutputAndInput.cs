using InternalUsers.DataAccess.Database.Models.Login;

namespace InternalUsers.DataAccess.Database.Models.Shared;

public class RoleDataBaseOutputAndInput
{
    public List<TokenDataBaseOutput>? Tokens { get; set; }
    public string RoleName { get; set; }
    public bool IsActive { get; set; }
    public Guid Id { get; set; }
    public DateTime CreatedDateTime { get; set; }
    public DateTime? ModifiedDateTime { get; set; }
}

public class RolesPaginatedDataBaseOutputAndInput
{
    public List<RoleDataBaseOutputAndInput>? Roles { get; set; }
    public int TotalRecords { get; set; }
}