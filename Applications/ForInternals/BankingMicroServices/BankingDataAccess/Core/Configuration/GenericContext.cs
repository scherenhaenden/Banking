using BankingDataAccess.Core.Domain;
using Microsoft.EntityFrameworkCore;

namespace BankingDataAccess.Core.Configuration;

public class GenericContext: DbContext
{
    private readonly string connectionString;
    public GenericContext(DbContextOptions<GenericContext> options) : base(options)
    {
        Database.EnsureCreated();
    }
    
    /*public GenericContext(string connectionString)
    {
        this.connectionString = connectionString;
    }*/
    
    // Add all of your entities here that are defined in the namespace BankingDataAccess.Core.Domain please read the types from that namespace
     public DbSet<AccountTypes> AccountTypes { get; set; }
     public DbSet<Addresses> Addresses { get; set; }
     public DbSet<BankAccounts> BankAccounts { get; set; }
     public DbSet<Currency> Currencies { get; set; }
     public DbSet<Customer> Customers { get; set; }
     /*public DbSet<CustomersToAddresses> CustomersToAddresses { get; set; }
     public DbSet<CustomerToBankAccount> CustomersToBankAccounts { get; set; }*/
     public DbSet<Transactions> Transactions { get; set; }
     public DbSet<TransactionTypes> TransactionsToBankAccounts { get; set; }
     
     public DbSet<Users> Users { get; set; }
     public DbSet<Roles> Roles { get; set; }
     public DbSet<Tokens> Tokens { get; set; }
     
        

    
    
}