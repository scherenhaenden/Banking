using BankingDataAccess.Core.Configuration;
using BankingDataAccess.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace InternalUsers.DataAccess.Database.Domain.InternalTokens;

public interface ITokensDataAccessDatabase
{
    // Add Method to get all the security tokens with pagination
    Task<IEnumerable<object>> GetSecurityTokensAsync(int skip, int take, CancellationToken cancellationToken = default);
    
    // Add Method to add new security token
    Task AddSecurityTokenAsync(Tokens token, CancellationToken cancellationToken = default);
    
    // Add Method to update existing security token
    Task UpdateSecurityTokenAsync(Tokens token, CancellationToken cancellationToken = default);
    
    // Add Method to delete existing security token
    Task DeleteSecurityTokenAsync(Tokens token, CancellationToken cancellationToken = default);
    
}

public class TokensDataAccessDatabase : ITokensDataAccessDatabase
{
    
    private readonly IUnitOfWorkV2 _unitOfWork;

    public TokensDataAccessDatabase(IUnitOfWorkV2 unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    
    
    public async Task<IEnumerable<object>> GetSecurityTokensAsync(int skip, int take, CancellationToken cancellationToken = default)
    {
        // If skip lower 1, set it to 1
        skip = skip < 1 ? 1 : skip;
        
        // reduce skip by 1
        skip -= 1;
        
        // Get all the security tokens with pagination
        var totalRecords = _unitOfWork.Tokens.GetAll().Count();
        
        var tokens = await _unitOfWork.Tokens.GetAll()
            .Skip(skip)
            .Take(take).ToListAsync();


        return tokens;

    }

    public Task AddSecurityTokenAsync(Tokens token, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task UpdateSecurityTokenAsync(Tokens token, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public Task DeleteSecurityTokenAsync(Tokens token, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}