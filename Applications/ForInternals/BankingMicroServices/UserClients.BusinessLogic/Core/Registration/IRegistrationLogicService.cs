using AutoMapper;
using Newtonsoft.Json;
using UserClients.BusinessLogic.Models.RegistrationDomain;
using UserClients.DataAccess.Core.Registration;
using UserClients.DataAccess.Models.RegistrationDomain;

namespace UserClients.BusinessLogic.Core.Registration;

public interface IRegistrationLogicService
{
    //Task<RegistrationResult> RegisterAsync(RegistrationRequest request);
    Task<bool> TryRegistration(UserRegistrationModelBusinessLogic request, out UserRegistrationModelBusinessLogic result);
}

public class RegistrationLogicService: IRegistrationLogicService
{
    private readonly IRegistrationDataAccessService _registrationDataAccessService;

    public RegistrationLogicService(IRegistrationDataAccessService registrationDataAccessService)
    {
        _registrationDataAccessService = registrationDataAccessService;
    }

    public Task<bool> TryRegistration(UserRegistrationModelBusinessLogic request, out UserRegistrationModelBusinessLogic result)
    {
        
        // Convert Obj to JSON
        var json = JsonConvert.SerializeObject(request);
        
        // Convert JSON to Obj of type UserRegistrationModelDataAccess
        var userRegistrationModelDataAccess = JsonConvert.DeserializeObject<UserRegistrationModelDataAccess>(json);
        
        
        /*var config = new MapperConfiguration(
            cfg => 
                cfg.CreateMap<UserRegistrationModelDataAccess,UserRegistrationModelBusinessLogic >()
                    .ForMember(x=> x.Addresses)
                    );
        
        var mapper = new Mapper(config);
        var dataAccessModel = mapper.Map<UserRegistrationModelDataAccess>(request);

         _registrationDataAccessService.TryRegistration(dataAccessModel, out var resultDataAccess);
        
        result = mapper.Map<UserRegistrationModelBusinessLogic>(resultDataAccess);*/
        
        _registrationDataAccessService.TryRegistration(userRegistrationModelDataAccess, out var resultDataAccess);
        
        // Convert Obj to JSON
        var jsonResult = JsonConvert.SerializeObject(resultDataAccess);
        
        // Convert JSON to Obj of type UserRegistrationModelBusinessLogic
        result = JsonConvert.DeserializeObject<UserRegistrationModelBusinessLogic>(jsonResult);
        
        
        return Task.FromResult(true);
    }
}