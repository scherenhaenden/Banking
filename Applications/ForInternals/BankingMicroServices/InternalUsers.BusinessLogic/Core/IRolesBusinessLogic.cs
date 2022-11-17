using InternalUsers.DataAccess.Core.Domain;

namespace InternalUsers.BusinessLogic.Core;

public interface IRolesBusinessLogic
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

public class RolesBusinessLogic: IRolesBusinessLogic
{
    private readonly IRolesDataAccess _rolesDataAccess;

    public RolesBusinessLogic(IRolesDataAccess rolesDataAccess)
    {
        _rolesDataAccess = rolesDataAccess;

    }
    
    public Task<object> GetRolesPaginatedAndTotalCount(int pageIndex, int pageSize)
    {
        return _rolesDataAccess.GetRolesPaginatedAndTotalCount(pageIndex, pageSize);
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
