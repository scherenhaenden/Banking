using BankingDataAccess.Core.Configuration;
using BankingDataAccess.Persistence.UnitiesOfWork;
using InternalUsers.BusinessLogic.Core;
using InternalUsers.DataAccess.Core.Domain;
using InternalUsers.DataAccess.Database.Domain.Login;
using InternalUsers.DataAccess.Database.Domain.Roles;
using InternalUsers.DataAccess.Database.Logic.Login;

namespace InternalUsers.Services.Dependencies;

public class ServiceCollectionCollector
{
    public IServiceCollection FillTheCollection(IServiceCollection serviceCollection)
    {
        
        serviceCollection.AddScoped<IUnitOfWorkV2, UnityOfWorkV2>();
        serviceCollection.AddScoped<ILoginDataAccessDataBase, LoginDataAccessDataBase>();
        serviceCollection.AddScoped<ILoginDataAccess, LoginDataAccess>();
        serviceCollection.AddScoped<ILogicBusinessLogic, LogicBusinessLogic>();
        
        serviceCollection.AddScoped<IRolesDataAccessDataBase, RolesDataAccessDataBase>();
        serviceCollection.AddScoped<IRolesDataAccess, RolesDataAccess>();
        serviceCollection.AddScoped<IRolesBusinessLogic, RolesBusinessLogic>();
        
        
        
        return serviceCollection;
    }
}