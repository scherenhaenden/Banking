using System.Linq.Expressions;
using BankingDataAccess.Core.BaseDomain;
using BankingDataAccess.Core.Domain;
using BankingDataAccess.Core.Repositories;

namespace BankingDataAccess.Core.Configuration;

public interface IUnityOfWork<T> where T : Entity, IEntity
{
    IRepository<T> Repository { get; }
    void Save();
}

public interface IUnitOfWorkV2: IDisposable
{

    IRepository<AccountTypes> AccountTypes { get; }
    
    IRepository<Addresses> Addresses { get; }
    
    IRepository<BankAccounts> BankAccounts { get; }
    
    IRepository<Currency> Currencies { get; }
    
    IRepository<Customer> Customers { get; }
    
    //IRepository<CustomersToAddresses> CustomersToAddresses { get; }
    
    //IRepository<CustomerToBankAccount> CustomersBankAccounts { get; }
    
    IRepository<Transactions> Transactions { get; }

    IRepository<TransactionTypes> TransactionTypes { get; }
    
    IRepository<Users> Users { get; }
    
    IRepository<Roles> Roles { get; }
    
    IRepository<Tokens> Tokens { get; }


    IQueryable<TEntity> GetAllIncluding<TEntity>(params Expression<Func<TEntity, object>>[] includeProperties)
        where TEntity : Entity, IEntity;

    
    int Complete();
}