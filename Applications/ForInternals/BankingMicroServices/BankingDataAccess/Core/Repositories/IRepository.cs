using System.Linq.Expressions;
using BankingDataAccess.Core.BaseDomain;
using Microsoft.EntityFrameworkCore;

namespace BankingDataAccess.Core.Repositories;


public interface IRepository<TEntity> where TEntity : Entity, IEntity
{
    /*Task<TEntity> GetByIdAsync(Guid id);
    Task<IEnumerable<TEntity>> GetAllAsync();
    Task AddAsync(TEntity entity);
    Task UpdateAsync(TEntity entity);
    Task DeleteAsync(TEntity entity);*/

    IQueryable<TEntity> GetAll();
    TEntity Get(Guid id);
    
    Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
    Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
    IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate);
    TEntity Add(TEntity entity);
    
    Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default);
    void AddRange(IEnumerable<TEntity> entities);
    void Remove(TEntity entity);
    
    Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default);
    void RemoveRange(IEnumerable<TEntity> entities);
    
    IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties);
    
    
    
    IQueryable<TEntity> GetAllIncluding(params string[] includeProperties);
    
    Task<IEnumerable<TEntity>> EntityWithEagerLoad(Expression<Func<TEntity, bool>> filter, string[] children, CancellationToken cancellationToken = default);
}

