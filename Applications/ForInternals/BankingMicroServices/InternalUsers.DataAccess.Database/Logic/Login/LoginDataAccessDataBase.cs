using BankingDataAccess.Core.Configuration;
using BankingDataAccess.Core.Domain;
using InternalUsers.DataAccess.Database.Domain.Login;
using InternalUsers.DataAccess.Database.Mappings;
using InternalUsers.DataAccess.Database.Models.Login;
using Newtonsoft.Json;

namespace InternalUsers.DataAccess.Database.Logic.Login;

public class LoginDataAccessDataBase: ILoginDataAccessDataBase
{
    private readonly IUnitOfWorkV2 _unitOfWork;
    

    public LoginDataAccessDataBase(IUnitOfWorkV2 unitOfWork)
    {
        _unitOfWork = unitOfWork;
        
    }

    public UserDatabaseOutput? GetUserInformationByEmployeeIdAndPassword(string employeeId, string encryptValue)
    {
        var user = _unitOfWork.Users.Where(x => x.EmployeeId == employeeId && x.Password == encryptValue).FirstOrDefault();
        
        if(user == null)
        {
            return null;
        }
        
        IMappingViaJson mappingViaJson = new MappingViaJson();
        var userObject =mappingViaJson.Map<UserDatabaseOutput>(user);

        return userObject;
    }

    public object? GetCustomerInformationByEmailAndPassword(string email, string encryptValue)
    {
        var user = _unitOfWork.Customers.Where(x => x.Email == email && x.Password == encryptValue).FirstOrDefault();

        return user;
    }
}