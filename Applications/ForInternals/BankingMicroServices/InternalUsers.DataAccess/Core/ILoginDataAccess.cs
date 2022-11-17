using InternalUsers.DataAccess.Database.Domain;

namespace InternalUsers.DataAccess.Core;

public interface ILoginDataAccess
{
    object GetUserInformationByUserNameAndPassword(string userName, string password);
    object GetUserInformationByEmployeeIdAndPassword(string employeeId, string encryptValue);
    object? GetCustomerInformationByEmailAndPassword(string email, string encryptValue);
}

public class LoginDataAccess: ILoginDataAccess
{
    private readonly ILoginDataAccessDataBase _loginDataAccessDataBase;


    public LoginDataAccess(ILoginDataAccessDataBase loginDataAccessDataBase)
    {
        _loginDataAccessDataBase = loginDataAccessDataBase;
    }
            
    
    
    public object GetUserInformationByUserNameAndPassword(string userName, string password)
    {
        return _loginDataAccessDataBase.GetUserInformationByUserNameAndPassword(userName, password);
    }

    public object GetUserInformationByEmployeeIdAndPassword(string employeeId, string encryptValue)
    {
        return _loginDataAccessDataBase.GetUserInformationByEmployeeIdAndPassword(employeeId, encryptValue);
    }

    public object? GetCustomerInformationByEmailAndPassword(string email, string encryptValue)
    {
        return _loginDataAccessDataBase.GetCustomerInformationByEmailAndPassword(email, encryptValue);
    }
}