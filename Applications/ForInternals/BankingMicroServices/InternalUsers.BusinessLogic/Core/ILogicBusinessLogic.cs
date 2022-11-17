using GenericTools.Security.Core;
using GenericTools.Security.Persistance;
using InternalUsers.DataAccess.Core;
using InternalUsers.DataAccess.Core.Domain;

namespace InternalUsers.BusinessLogic.Core;

public interface ILogicBusinessLogic
{
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