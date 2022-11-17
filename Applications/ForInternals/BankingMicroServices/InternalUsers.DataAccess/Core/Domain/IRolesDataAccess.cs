using InternalUsers.DataAccess.Database.Domain.Roles;

namespace InternalUsers.DataAccess.Core.Domain;

public interface IRolesDataAccess
{
    // Add Method to get roles with paginagion and total count
    Task<object> GetRolesPaginatedAndTotalCount(int pageIndex, int pageSize);
    
    // Add Method to add new role
    Task<object> AddRoleAsync(object role, CancellationToken cancellationToken = default);
    
    // Add Method to update role
    Task<object> UpdateRoleAsync(object role, CancellationToken cancellationToken = default);
    
    // Add Method to delete role
    Task DeleteRoleAsync(object role, CancellationToken cancellationToken = default);
    
    
}

public class RolesDataAccess: IRolesDataAccess
{
    private readonly IRolesDataAccessDataBase _rolesDataAccessDataBase;

    public RolesDataAccess(IRolesDataAccessDataBase rolesDataAccessDataBase)
    {
        _rolesDataAccessDataBase = rolesDataAccessDataBase;
    }
    
    public async Task<object> GetRolesPaginatedAndTotalCount(int pageIndex, int pageSize)
    {
        // Get Roles from database
        var result = await _rolesDataAccessDataBase.GetRolesAsync(pageIndex, pageSize);
        // map
        return Task.FromResult(result);
    }

    public Task<object> AddRoleAsync(object role, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task<object> UpdateRoleAsync(object role, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteRoleAsync(object role, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}