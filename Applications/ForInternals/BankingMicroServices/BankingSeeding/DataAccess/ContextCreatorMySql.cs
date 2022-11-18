using Microsoft.EntityFrameworkCore;

namespace BankingSeeding.DataAccess;

public class ContextCreatorMySql<T>: IContextCreator<T>where T: DbContext
{
    public T CreateContext(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<T>();
        optionsBuilder.UseLazyLoadingProxies().UseMySQL(connectionString);
        return (T)Activator.CreateInstance(typeof(T), optionsBuilder.Options);
    }
   
    public void DisposeContext(T context)
    {
        
        //context.Database.EnsureDeleted();
        context.Dispose();
    }

}