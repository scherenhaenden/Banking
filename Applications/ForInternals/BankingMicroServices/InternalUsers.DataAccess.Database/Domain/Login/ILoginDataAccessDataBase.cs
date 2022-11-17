using InternalUsers.DataAccess.Database.Models.Login;

namespace InternalUsers.DataAccess.Database.Domain.Login;

public interface ILoginDataAccessDataBase
{
    UserDatabaseOutput? GetUserInformationByEmployeeIdAndPassword(string employeeId, string encryptValue);
    object? GetCustomerInformationByEmailAndPassword(string email, string encryptValue);
}