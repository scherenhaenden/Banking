namespace UserClients.DataAccess.Models;

public class CustomerToAddressId: BaseModel
{
    public Guid CustomerId { get; set; }
    public Guid AddressId { get; set; }
}

public class Addresses: BaseModel
{
    public string Country { get; set; }
    public string City { get; set; }
    public string Street { get; set; }
    public string PostalCode { get; set; }
    public string HouseNumber { get; set; }
    public string ApartmentNumber { get; set; }
    public string ExtraInformation { get; set; }
}

public class CustomerToAccountId: BaseModel
{
    public Guid CustomerId { get; set; }
    public Guid AccountId { get; set; }
}

public class Customer: BaseModel
/*{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PhoneNumber { get; set; }
    public string Password { get; set; }
    public string Salt { get; set; }
    public string Role { get; set; }
    public string Status { get; set; }
    public string Token { get; set; }
    public string TokenExpiration { get; set; }
    public string RefreshToken { get; set; }
    public string RefreshTokenExpiration { get; set; }
    public string ExtraInformation { get; set; }
}*/
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