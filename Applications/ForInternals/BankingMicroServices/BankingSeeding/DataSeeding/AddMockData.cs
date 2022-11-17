using BankingDataAccess.Core.Domain;

namespace BankingSeeding.DataSeeding;

public class AddMockData
{
    // Create Method to create dummy list of customers
    /*public static List<Customer> CreateCustomers()
    {
        List<Customer> customers = new List<Customer>();
        customers.Add(new Customer
            {
                Id = new Guid(), FirstName = "John", LastName = "Doe", Email = "John.Doe@someemail.com",
                PhoneNumber = "1234567890", DateOfSignup = DateTime.Now, DateOfBirth = GenerateRandomDate(),
                TypeOfCustomer = "Personal", Passport = "D9876432", Password = "test", NationalId = "DE"
            },
            new Customer
            {
                Id = new Guid(), FirstName = "Jane", LastName = "Doe", Email = "Jane.Doe@someemail.com",
                PhoneNumber = "1234567890", DateOfSignup = DateTime.Now,
                DateOfBirth = GenerateRandomDate(), TypeOfCustomer = "Personal", Passport = "D9876432",
                Password = "test",
                NationalId = "DE"
            },
            new Customer
            {
                Id = new Guid(), FirstName = "Max", LastName = "Mustermann", Email = "Max.Mustermann@someemail.com",
                PhoneNumber = "1234567890", DateOfSignup = DateTime.Now,
                DateOfBirth = GenerateRandomDate(), TypeOfCustomer = "Personal", Passport = "D9876432",
                Password = "test",
                NationalId = "DE"
            });


    }*/
    
    
    // Create Method to that generates random Date older than 18 years but younger than 100 years
    public static DateTime GenerateRandomDate()
    {
        DateTime start = new DateTime(1920, 1, 1);
        Random gen = new Random();
        int range = (DateTime.Today - start).Days;
        return start.AddDays(gen.Next(range));
    }
    
}