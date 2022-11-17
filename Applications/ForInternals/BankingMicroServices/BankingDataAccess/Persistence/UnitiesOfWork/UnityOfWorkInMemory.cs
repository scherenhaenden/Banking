using System.Linq.Expressions;
using System.Reflection;
using BankingDataAccess.Core.BaseDomain;
using BankingDataAccess.Core.Configuration;
using BankingDataAccess.Core.Domain;
using BankingDataAccess.Core.Repositories;
using BankingDataAccess.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;

namespace BankingDataAccess.Persistence.UnitiesOfWork;

public class GenericUnitOfWork<TRepo, TEntity> : IDisposable, IUnityOfWork<TEntity>
    where TRepo : Repository<TEntity> where TEntity: Entity, IEntity
{
    // Initialization code

    public Dictionary<Type, TRepo> repositories = new Dictionary<Type, TRepo>();
    private IRepository<TEntity> _repository;

    public TRepo Repository()
    {
        if (repositories.Keys.Contains(typeof(TEntity)) == true)
        {
            return repositories[typeof(TEntity)];
        }
        TRepo repo = (TRepo)Activator.CreateInstance(
            typeof(TRepo),
            new object[] { /*put there parameters to pass*/ });
        repositories.Add(typeof(TEntity), repo);
        return repo;
    }

    // other methods
    public void Dispose()
    {
        throw new NotImplementedException();
    }

    IRepository<TEntity> IUnityOfWork<TEntity>.Repository => _repository;

    public void Save()
    {
        throw new NotImplementedException();
    }
}


public class UnityOfWorkInMemory<TEntity>: IUnityOfWork<TEntity> where TEntity: Entity, IEntity
{
    private GenericContext _context;
    
    public UnityOfWorkInMemory(GenericContext context)
    {
        _context = context;
        Repository = new Repository<TEntity>(context);
        
        
        repositories.Add(typeof(TEntity), _context.Set<TEntity>());
        
        
    }
    
    public Dictionary<Type, DbSet<TEntity>> repositories = new Dictionary<Type, DbSet<TEntity>>();


    
    
    public IRepository<TEntity> Repository { get; }
    public void Save()
    {
        _context.SaveChanges();
    }
}

public class UnityOfWorkV2 : IUnitOfWorkV2
{
    private readonly GenericContext _context;

    public UnityOfWorkV2(GenericContext context)
    {
        _context = context;
        InitAllPropertiesOfGenericIRepository();
        
        /*AccountTypes = new Repository<AccountTypes>(_context);
        Addresses = new Repository<Addresses>(_context);
        BankAccounts = new Repository<BankAccount>(_context);
        Currencies = new Repository<Currency>(_context);
        Customers = new Repository<Customer>(_context);
        
        CustomersToAddresses = new Repository<CustomersToAddresses>(_context);
        CustomersBankAccounts = new Repository<CustomerToBankAccount>(_context);
        Transactions = new Repository<Transactions>(_context);
        TransactionTypes = new Repository<TransactionTypes>(_context);
        
        Users = new Repository<Users>(_context);*/
        
        _context.Database.EnsureCreated();

        
    }
    public void Dispose()
    {
        _context.Dispose();
    }
    
    public void InitAllPropertiesOfGenericIRepository ()
    {
        // Get All Properties of current class that are public and of type IRepository
        var properties = this.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance)
            .Where(p => p.PropertyType.IsGenericType && p.PropertyType.GetGenericTypeDefinition() == typeof(IRepository<>)).ToList();
        
        // Get All Properties of current class that are public and of type IRepository that are not initiated
        var propertiesNotInitiated = properties.Where(p => p.GetValue(this) == null).ToList();
        
        // Initiate all properties that are not initiated
        foreach (var property in propertiesNotInitiated)
        {
            // Get the type of the generic parameter of the property
            var genericType = property.PropertyType.GetGenericArguments()[0];
            
            // Get the type of the Repository that is used to access the generic type
            var repositoryType = typeof(Repository<>).MakeGenericType(genericType);
            
            // Create an instance of the repository
            var repository = Activator.CreateInstance(repositoryType, _context);
            
            // Set the value of the property to the repository
            property.SetValue(this, repository);
            
            // Init property using this pattern TransactionTypes = new Repository<TransactionTypes>(_context);
            
            
            
            
            
            
        }
        
        
        
    }

    public IRepository<AccountTypes> AccountTypes { get; private set; }
    public IRepository<Addresses> Addresses { get; private set; }
    public IRepository<BankAccounts> BankAccounts { get; private set; }
    public IRepository<Currency> Currencies { get; private set;  }
    public IRepository<Customer> Customers { get; private set; }
    /*public IRepository<CustomersToAddresses> CustomersToAddresses { get; private set; }
    public IRepository<CustomerToBankAccount> CustomersBankAccounts { get; private set; }*/
    public IRepository<Transactions> Transactions { get; private set; }
    public IRepository<TransactionTypes> TransactionTypes { get; private set; }
    public IRepository<Users> Users { get; private set; }
    public IRepository<Roles> Roles { get; private set;}
    public IRepository<Tokens> Tokens { get; private set;}

    public IQueryable<TEntity> GetAllIncluding<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties) where TEntity : Entity, IEntity
    {
        IQueryable<TEntity> query = _context.Set<TEntity>();
        return includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
    }

    public int Complete()
    {
        return _context.SaveChanges();
    }
}
