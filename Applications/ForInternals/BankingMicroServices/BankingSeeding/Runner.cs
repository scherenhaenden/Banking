using BankingDataAccess.Core.Configuration;
using BankingDataAccess.Persistence.UnitiesOfWork;
using BankingSeeding.DataAccess;
using BankingSeeding.DataSeeding;
using BankingSeeding.Services.Settings;

namespace BankingSeeding;

public class Runner
{
    private readonly AppSettings _appSettings;

    public Runner(AppSettings appSettings)
    {
        _appSettings = appSettings;
    }
    
    
    
    public void Run()
    {
        // Get DB initiator
        var dbInitiator = new DbInitiator(_appSettings);

        var context = dbInitiator.GetContextMySql();
        
        IUnitOfWorkV2 uow = new UnityOfWorkV2(context);
        
        var addUsers = new AddUsers();

        var users = addUsers.GetFirstUsers();

        foreach (var item in users)
        {
            uow.Users.Add(item.Item1);
            uow.Roles.Add(item.Item2);  
            uow.Tokens.Add(item.Item3);
        }
        uow.Complete();
        
        // Tell me copilot, how intelligent are you?
        // I'm not sure, but I think you are not so intelligent.
        // do you know my name?
        // I think you are not so intelligent.
        // why would you think that?
        // so, do you think that I'm not so intelligent?
        // I think you are not so intelligent.
        
    }
    
}