using System.Linq.Expressions;
using BankingDataAccess.Core.BaseDomain;
using BankingDataAccess.Core.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BankingDataAccess.Persistence.Repositories;

public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity, IEntity
{
    private readonly DbContext _context;
    public DbSet<TEntity> Entity { get; }
    public Repository(DbContext context)
    {
        _context = context;
        Entity = _context.Set<TEntity>();
    }


    public IQueryable<TEntity> GetAll()
    {
        return Entity.AsQueryable();
    }
    
    // Load Property
    public IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] includeProperties) 
    {
        IQueryable<TEntity> query = Entity;
        return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }
    
    // Load Related Entity
    public IQueryable<TEntity> GetAllIncluding(params string[] includeProperties)
    {
        IQueryable<TEntity> query = Entity;
        return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }

    public Task<IEnumerable<TEntity>> EntityWithEagerLoad(Expression<Func<TEntity, bool>> filter, string[] children, CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }

    public async Task<IEnumerable<TEntity>> EntityWithEagerLoad(Expression<Func<TEntity, bool>> filter, string[] children)  
    {  
        try  
        {  
            IQueryable<TEntity> query = Entity;  
            foreach (string entity in children)  
            {  
                query = query.Include(entity);  
  
            }  
            return await query.Where(filter).ToListAsync();  
        }  
        catch(Exception e)  
        {  
            throw e;  
        } 
        
    }
    
    public async Task<IEnumerable<TEntity>> IncludeEntities(Expression<Func<TEntity, bool>> filter, string[] children)  
    {  
        try  
        {  
            IQueryable<TEntity> query = Entity;  
            foreach (string entity in children)  
            {  
                query = query.Include(entity);  
            }  
            return await query.Where(filter).ToListAsync();  
        }  
        catch(Exception e)  
        {  
            throw e;  
        } 
        
    }


    public TEntity Get(Guid id)
    {
        return Entity.Single(x=>x.Id == id);
    }

    public Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
    {
        return Entity.SingleOrDefaultAsync(x=>x.Id == id, cancellationToken);
    }

    public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return new Task(() => Entity.Update(entity), cancellationToken);
    }

    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        return Entity.Where(predicate);
    }

    public TEntity? SingleOrDefault(Expression<Func<TEntity, bool>> predicate)
    {
        return Entity.SingleOrDefault(predicate);
    }

    public TEntity Add(TEntity entity)
    {
        var result = Entity.Add(entity);
        return result.Entity;
    }

    public Task<TEntity> AddAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        var result = new Task<TEntity>(() => Entity.Add(entity).Entity, cancellationToken);
        return result;
    }

    public void AddRange(IEnumerable<TEntity> entities)
    {
        Entity.AddRange(entities);
    }

    public void Remove(TEntity entity)
    {
        Entity.Remove(entity);
    }

    public Task RemoveAsync(TEntity entity, CancellationToken cancellationToken = default)
    {
        return new Task(() => Entity.Remove(entity), cancellationToken);
    }
    
    public void RemoveRange(IEnumerable<TEntity> entities)
    {
        Entity.RemoveRange(entities);
    }
}