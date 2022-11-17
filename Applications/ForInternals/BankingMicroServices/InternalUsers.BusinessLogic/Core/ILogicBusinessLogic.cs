using GenericTools.Security.Core;
using GenericTools.Security.Persistance;
using InternalUsers.DataAccess.Core;

namespace InternalUsers.BusinessLogic.Core;

public interface ILogicBusinessLogic
{
    object GetUserInformationByUserNameAndPassword(string userName, string password);
    object GetUserInformationByEmployeeIdAndPassword(string employeeId, string password);
    object? GetCustomerInformationByEmailAndPassword(string email, string password);
}

public class LogicBusinessLogic: ILogicBusinessLogic
{
    private readonly ILoginDataAccess _loginDataAccess;


    public LogicBusinessLogic(ILoginDataAccess loginDataAccess)
    {
        _loginDataAccess = loginDataAccess;
    }
            
    
    
    public object GetUserInformationByUserNameAndPassword(string userName, string password)
    {
        ISimpleEncryptionService simpleEncryptionService = new SimpleEncryptionServiceMd5();
        
        
        return _loginDataAccess.GetUserInformationByUserNameAndPassword(userName, simpleEncryptionService.EncryptValue( password));
    }

    public object GetUserInformationByEmployeeIdAndPassword(string employeeId, string password)
    {
        ISimpleEncryptionService simpleEncryptionService = new SimpleEncryptionServiceMd5();
        
        
        return _loginDataAccess.GetUserInformationByEmployeeIdAndPassword(employeeId, simpleEncryptionService.EncryptValue( password));
    }

    public object? GetCustomerInformationByEmailAndPassword(string email, string password)
    {
        ISimpleEncryptionService simpleEncryptionService = new SimpleEncryptionServiceMd5();
        
        
        return _loginDataAccess.GetCustomerInformationByEmailAndPassword(email, simpleEncryptionService.EncryptValue( password));
    }
}