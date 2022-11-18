using BankingDataAccess.Core.Configuration;
using BankingSeeding.Services.Settings;
using Microsoft.EntityFrameworkCore;

namespace BankingSeeding.DataAccess;

public class DbInitiator
{
    private readonly AppSettings _appSettings;
    /*public static void Initiate()
    {
        using var context = new BankingContext();
        context.Database.Migrate();
    }*/

    public DbInitiator(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }
    
    // Create private method that Initialize database memory
    private DbContext InitAndGet(string connectionString, IContextCreator<GenericContext> iContextCreator) 
    {       
        var value = iContextCreator.CreateContext(connectionString);
        return value;
    }
    
    public DbContext InitiateAndGet(string contextName, string type, string connectionString)
    {
        if (contextName.ToLower() == "GenericContext".ToLower())
        {
            if (type == "memory")
            {
                IContextCreator<GenericContext> contextCreator = new ContextCreatorInMemory<GenericContext>();
            
                return InitAndGet(connectionString, contextCreator);
            }
            
            if (type == "mysql")
            {
                IContextCreator<GenericContext> contextCreator = new ContextCreatorMySql<GenericContext>();
            
                return InitAndGet(connectionString, contextCreator);
            }
            
            if( type == "sqlserver")
            {
                IContextCreator<GenericContext> contextCreator = new ContextCreatorSqlServer<GenericContext>();
            
                return InitAndGet(connectionString, contextCreator);
            }
            
            if( type == "mysql")
            {
                IContextCreator<GenericContext> contextCreator = new ContextCreatorMySql<GenericContext>();
            
                return InitAndGet(connectionString, contextCreator);
            }
            
        }

        return null;

    }
    
    
    
    public GenericContext GetInMemoryContext()
    {
        return new ContextGenerator().GetContextInMemory();
    }
    
    public GenericContext GetSqliteContext()
    {
        return new ContextGenerator().GetContextSqlite();
    }
    
    public GenericContext GetContextMySql()
    {
        return new ContextGenerator().GetContextMySql();
    }
}

public class ContextCreatorSqlServer<T> : IContextCreator<GenericContext>
{
    public GenericContext CreateContext(string connectionString)
    {
        /*var optionsBuilder = new DbContextOptionsBuilder<GenericContext>();
        optionsBuilder.UseSqlServer(connectionString);
        return new GenericContext(optionsBuilder.Options);*/
        throw new NotImplementedException();
    }

    public void DisposeContext(GenericContext context)
    {
        throw new NotImplementedException();
    }
}

public class ContextCreatorSqlite<T>: IContextCreator<T>where T: DbContext
{   
    public T CreateContext(string connectionString)
    {
        var optionsBuilder = new DbContextOptionsBuilder<T>();
        optionsBuilder.UseLazyLoadingProxies().UseSqlite(connectionString);
        return (T)Activator.CreateInstance(typeof(T), optionsBuilder.Options);
    }
   
    public void DisposeContext(T context)
    {
        
        //context.Database.EnsureDeleted();
        context.Dispose();
    }
}

public class ContextGenerator
{

    
    // Add method to get generate memory database
    public GenericContext GetContextInMemory()
    {
        var optionsBuilder = new DbContextOptionsBuilder<GenericContext>();
        optionsBuilder.UseLazyLoadingProxies().UseInMemoryDatabase("BankingSeeding");
        return new GenericContext(optionsBuilder.Options);
    }
    
    // Add method to get generate sqlite database
    public GenericContext GetContextSqlite()
    {
        var optionsBuilder = new DbContextOptionsBuilder<GenericContext>();
        optionsBuilder.UseLazyLoadingProxies().UseSqlite("Data Source=../../../../../../../Data/BankingSeeding.db");
        return new GenericContext(optionsBuilder.Options);
    }
    
    // Add method to get generate mysql database
    public GenericContext GetContextMySql()
    {
        
        //"server=127.0.0.1;uid=root;pwd=12345;database=test"
        
        
        var optionsBuilder = new DbContextOptionsBuilder<GenericContext>();
        optionsBuilder.UseLazyLoadingProxies().UseMySQL("Server=localhost; Port=13306;database=db;uid=root;pwd=password");
        return new GenericContext(optionsBuilder.Options);
    }
}