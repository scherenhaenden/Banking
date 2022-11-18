using System.Security;
using BankingDataAccess.Core.Configuration;
using Microsoft.EntityFrameworkCore;

namespace BankingSeeding.DataAccess;

public class ContextCreatorInMemory<T>: IContextCreator<T> where T: DbContext
{
    public T CreateContext(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<T>();
        optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase(connectionString);
        return (T)Activator.CreateInstance(typeof(T), optionsBuilder.Options);
    }
   
    public void DisposeContext(T context)
    {
        
        //context.Database.EnsureDeleted();
        context.Dispose();
    }
   
}