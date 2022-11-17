using AutoMapper;
using BankingDataAccess.Core.Configuration;
using BankingDataAccess.Core.Domain;
using Newtonsoft.Json;
using UserClients.DataAccess.Database.Models.Registration;

namespace UserClients.DataAccess.Database.Logic;

public interface IRegistrationDataAccess
{
    Task<bool> TryRegistration(UserRegistrationModelData request, out UserRegistrationModelData result);

}



public class RegistrationDataAccess: IRegistrationDataAccess
{
    private readonly IUnityOfWork<Customer> _customerUow;
    private readonly IUnityOfWork<Addresses> _addressesUow;
    

    public RegistrationDataAccess(
        IUnityOfWork<Customer> customerUow, 
        IUnityOfWork<Addresses> addressesUow
    )
    {
        _customerUow = customerUow;
        _addressesUow = addressesUow;
    }
    
    public void AddCustomer(Customer customer)
    {
        _customerUow.Repository.Add(customer);
    }
    
    public void AddAddress(Addresses address)
    {
        _addressesUow.Repository.Add(address);
    }
    public void Commit()
    {
        _customerUow.Save();
    }

    public Task<bool> TryRegistration(UserRegistrationModelData request, out UserRegistrationModelData result)
    { 

  
        var customer = JsonConvert.DeserializeObject<Customer>(JsonConvert.SerializeObject(request.Customer));
        
        var addresses = JsonConvert.DeserializeObject<Addresses>(JsonConvert.SerializeObject(request.Addresses));
        
        
        AddCustomer(customer);
        AddAddress(addresses);
        
        //eAddCustomerToAddressId(customersToAddresses);

        result = request;
        
        return Task.FromResult(true);
        
        
        
       
    }
}