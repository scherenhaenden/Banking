namespace UserClients.DataAccess.Database.Models.Registration;

public class UserRegistrationModelData
{

    public CustomerInput Customer { get; set; }
    
    public AddressesInput Addresses { get; set; }

}


public class AddressesInput: BaseModel
{
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public string HouseNumber { get; set; }
    public string ApartmentNumber { get; set; }
    public string ExtraInformation { get; set; }
}

public class CustomerInput: BaseModel
{
    public Guid CustomerToAddressId { get; set; }
    public DateTime DateOfSignup { get; set; }
    public string TypeOfCustomer { get; set; } = null!;
    public DateTime DateOfBirth { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Passport { get; set; }
    public string NationalId { get; set; }
}

