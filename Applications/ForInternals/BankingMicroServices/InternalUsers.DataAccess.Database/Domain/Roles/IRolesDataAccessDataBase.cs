using InternalUsers.DataAccess.Database.Models.Login;
using InternalUsers.DataAccess.Database.Models.Shared;

namespace InternalUsers.DataAccess.Database.Domain.Roles;

public interface IRolesDataAccessDataBase
{
    // Add Method to get all roles with pagination
    Task<RolesPaginatedDataBaseOutputAndInput> GetRolesAsync(int skip, int take, CancellationToken cancellationToken = default);
    
    // Add Method to add new role
    Task<RoleDataBaseOutputAndInput> AddRoleAsync(RoleDataBaseOutputAndInput role, CancellationToken cancellationToken = default);
    
    // Add Method to update role
    Task<RoleDataBaseOutputAndInput> UpdateRoleAsync(RoleDataBaseOutputAndInput role, CancellationToken cancellationToken = default);
    
    // Add Method to delete role
    Task DeleteRoleAsync(RoleDataBaseOutputAndInput role, CancellationToken cancellationToken = default);
}