using AutoMapper;
using BankingDataAccess.Core.Configuration;
using BankingDataAccess.Core.Domain;
using InternalUsers.DataAccess.Database.Models.Login;
using Mapster;
using Newtonsoft.Json;

namespace InternalUsers.DataAccess.Database.Domain;

public class LoginDataAccessDataBase: ILoginDataAccessDataBase
{
    private readonly IUnitOfWorkV2 _unitOfWork;

    public LoginDataAccessDataBase(IUnitOfWorkV2 unitOfWork)
    {
        _unitOfWork = unitOfWork;
        
    }
    
    public object GetUserInformationByUserNameAndPassword(string userName, string password)
    {
        
        var user = _unitOfWork.Users.Where(x => x.UserName == userName && x.Password == password).FirstOrDefault();

        return user;
    }

    public object GetUserInformationByEmployeeIdAndPassword(string employeeId, string encryptValue)
    {
        var user = _unitOfWork.Users.Where(x => x.EmployeeId == employeeId && x.Password == encryptValue).FirstOrDefault();
        
        
        // Create settings for JSON serialization.
        var settings = new JsonSerializerSettings
        {
            //TypeNameHandling = TypeNameHandling.All
            PreserveReferencesHandling = PreserveReferencesHandling.Objects
        };
        
        // Create JSON serializer using the settings from above
        var serializer = JsonSerializer.Create(settings);
        
        
        // Parse object to json using the serializer
        var json = JsonConvert.SerializeObject(user, Formatting.Indented, settings);
        //var json = JsonConvert.SerializeObject(user);
        
        
        // Parse json to object
        var userObject = JsonConvert.DeserializeObject<UserDatabaseOutput>(json);


        return userObject;
    }

    public object? GetCustomerInformationByEmailAndPassword(string email, string encryptValue)
    {
        var user = _unitOfWork.Customers.Where(x => x.Email == email && x.Password == encryptValue).FirstOrDefault();

        return user;
    }
}