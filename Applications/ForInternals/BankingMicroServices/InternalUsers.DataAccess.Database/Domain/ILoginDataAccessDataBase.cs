namespace InternalUsers.DataAccess.Database.Domain;

public interface ILoginDataAccessDataBase
{
    object GetUserInformationByUserNameAndPassword(string userName, string password);
    object GetUserInformationByEmployeeIdAndPassword(string employeeId, string encryptValue);
    object? GetCustomerInformationByEmailAndPassword(string email, string encryptValue);
}