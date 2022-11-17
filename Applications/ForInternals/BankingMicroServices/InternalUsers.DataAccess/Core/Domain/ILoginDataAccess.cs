using InternalUsers.DataAccess.Database.Domain.Login;

namespace InternalUsers.DataAccess.Core.Domain;

public interface ILoginDataAccess
{
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


    public object GetUserInformationByEmployeeIdAndPassword(string employeeId, string encryptValue)
    {
        return _loginDataAccessDataBase.GetUserInformationByEmployeeIdAndPassword(employeeId, encryptValue);
    }

    public object? GetCustomerInformationByEmailAndPassword(string email, string encryptValue)
    {
        return _loginDataAccessDataBase.GetCustomerInformationByEmailAndPassword(email, encryptValue);
    }
}