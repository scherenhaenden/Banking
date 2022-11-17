using BankingDataAccess.Core.Configuration;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace InternalUsers.Controllers;

[ApiController]
[Route("[controller]")]
public class RolesController : Controller
{
    private readonly IUnitOfWorkV2 _unitOfWork;

    public RolesController(IUnitOfWorkV2 unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    // Create method that Allow Anonymous is httpPost  with Route AddRole that Accepts RoleDto as parameter
    [AllowAnonymous]
    [HttpPost]
    [Route("AddRole")]
    public async Task<IActionResult> AddRole(RoleDto roleDto)
    {
        // Create new Role
        var role = new Role
        {
            Name = roleDto.Name,
            Description = roleDto.Description
        };
        // Add Role to Database
        await _unitOfWork.Roles.AddAsync(role);
        // Save Changes
        await _unitOfWork.SaveChangesAsync();
        // Return Ok
        return Ok();
    }
    
    // Create method that Allow Anonymous is httpPut  with Route UpdateTole that Accepts RoleDto as parameter
    [AllowAnonymous]
    [HttpPut]
    [Route("UpdateRole")]
    public async Task<IActionResult> UpdateRole(RoleDto roleDto)
    {
        // Get Role from Database
        var role = await _unitOfWork.Roles.GetByIdAsync(roleDto.Id);
        // Check if Role is null
        if (role == null)
        {
            // Return NotFound
            return NotFound();
        }
        // Update Role
        role.Name = roleDto.Name;
        role.Description = roleDto.Description;
        // Update Role in Database
        _unitOfWork.Roles.Update(role);
        // Save Changes
        await _unitOfWork.SaveChangesAsync();
        // Return Ok
        return Ok();
    }
    
    
    // Create method that Allow Anonymous is httpGet with Route GetRolesByPagination that Accepts int page and int pageSize
    [AllowAnonymous]
    [HttpGet]
    [Route("GetRolesByPagination")]
    public async Task<IActionResult> GetRolesByPagination(int page, int pageSize)
    {
        // if page is less than 1 or pageSize is less than 1 return BadRequest
        if (page < 1 || pageSize < 1)
        {
            page = 1;
            pageSize = 10;
        }
        
        
        // Create a variable of type PagedList<Role> and assign it to the result of the GetRolesByPagination method of the RoleRepository class
        //var roles = await _unitOfWork.Roles.GetRolesByPagination(page, pageSize);



        var roles = _unitOfWork
                .Roles
                .GetAll()
            ;//.Include(x => x.RolePermissions).ThenInclude(x => x.Permission).ToList();
        roles.ToList().Skip(pageSize * page).Take(pageSize);
        
        
        // Return the roles variable
        return Ok(roles);
    }
    
    
    /*
     * public static class PagingExtensions
{
    //used by LINQ to SQL
    public static IQueryable<TSource> Page<TSource>(this IQueryable<TSource> source, int page, int pageSize)
    {
        return source.Skip((page - 1) * pageSize).Take(pageSize);
    }

    //used by LINQ
    public static IEnumerable<TSource> Page<TSource>(this IEnumerable<TSource> source, int page, int pageSize)
    {
        return source.Skip((page - 1) * pageSize).Take(pageSize);
    }

}
     */
    
 
}