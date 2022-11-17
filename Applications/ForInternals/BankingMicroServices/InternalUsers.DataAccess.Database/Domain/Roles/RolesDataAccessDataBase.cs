using BankingDataAccess.Core.Configuration;
using InternalUsers.DataAccess.Database.Mappings;
using InternalUsers.DataAccess.Database.Models.Shared;
using Microsoft.EntityFrameworkCore;

namespace InternalUsers.DataAccess.Database.Domain.Roles;

public class RolesDataAccessDataBase : IRolesDataAccessDataBase
{
    private readonly IUnitOfWorkV2 _unitOfWork;

    public RolesDataAccessDataBase(IUnitOfWorkV2 unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<RolesPaginatedDataBaseOutputAndInput> GetRolesAsync(int skip, int take, CancellationToken cancellationToken = default)
    {
        // If skip lower 1, set it to 1
        skip = skip < 1 ? 1 : skip;
        
        // reduce skip by 1
        skip -= 1;
    
        
        
        var totalRecords = _unitOfWork.Roles.GetAll().Count();
        
        var roles = await _unitOfWork.Roles.GetAll()
            .Skip(skip)
            .Take(take).ToListAsync();
            
        //.ToList();
        IMappingViaJson mappingViaJson = new MappingViaJson();
        var roleDataBaseOutputAndInputs = mappingViaJson.Map<List<RoleDataBaseOutputAndInput>>(roles);
        
        var rolesPaginatedDataBaseOutputAndInput = new RolesPaginatedDataBaseOutputAndInput
        {
            TotalRecords = totalRecords,
            Roles = roleDataBaseOutputAndInputs
        };

        return rolesPaginatedDataBaseOutputAndInput;
    }

    public Task<RoleDataBaseOutputAndInput> AddRoleAsync(RoleDataBaseOutputAndInput role, CancellationToken cancellationToken = default)
    {
        // Add new role
        IMappingViaJson mappingViaJson = new MappingViaJson();
        var roleDbObject =mappingViaJson.Map<BankingDataAccess.Core.Domain.Roles>(role);
        
        _unitOfWork.Roles.Add(roleDbObject);
        
        throw new NotImplementedException();
    }

    public Task<RoleDataBaseOutputAndInput> UpdateRoleAsync(RoleDataBaseOutputAndInput role, CancellationToken cancellationToken = default)
    {
        IMappingViaJson mappingViaJson = new MappingViaJson();
        var roleDbObject =mappingViaJson.Map<BankingDataAccess.Core.Domain.Roles>(role);
        
        _unitOfWork.Roles.UpdateAsync(roleDbObject, cancellationToken);
        
        throw new NotImplementedException();
    }

    public Task DeleteRoleAsync(RoleDataBaseOutputAndInput role, CancellationToken cancellationToken = default)
    {
        IMappingViaJson mappingViaJson = new MappingViaJson();
        var roleDbObject =mappingViaJson.Map<BankingDataAccess.Core.Domain.Roles>(role);
        
        return _unitOfWork.Roles.RemoveAsync(roleDbObject, cancellationToken);
    }
}