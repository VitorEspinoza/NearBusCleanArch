using NearBusCleanArch.Domain.Validation;

namespace NearBusCleanArch.Domain.Entities
{
    public class Adress : Entity
    {
        public string Street { get; private set; }
        public string Neighborhood { get; private set; }
        public string City { get; private set; }
        public string State { get; private set; }
        public string Number { get; private set; }
        public string ZipCode {  get; private set; }
    
    public Adress(string street, string neighborhood, string city, string state, string number, string zipCode)
    {
        ValidateDomain(street, neighborhood, city, state, number, zipCode);
    }

    public Adress(int id, string street, string neighborhood, string city, string state, string number, string zipCode)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value");
        Id = id;
        ValidateDomain(street, neighborhood, city, state,number, zipCode);
    }

    public void Update(string street, string neighborhood, string city, string state, string number, string zipCode)
    {
        ValidateDomain(street, neighborhood, city, state, number, zipCode);
    }
    private void ValidateDomain(string street, string neighborhood, string city, string state, string number, string zipCode)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(street), "Invalid street. Street is required");
        DomainExceptionValidation.When(street.Length < 10, "Invalid street, too short. Minimum 10 characters.");
        
        DomainExceptionValidation.When(string.IsNullOrEmpty(neighborhood), "Invalid neighborhood. Neighborhood is required");
        DomainExceptionValidation.When(neighborhood.Length < 5, "Invalid street, too short. Minimum 5 characters.");
        
        DomainExceptionValidation.When(string.IsNullOrEmpty(city), "Invalid city. City is required");
        DomainExceptionValidation.When(city.Length < 10, "Invalid city, too short. Minimum 4 characters.");
        
        DomainExceptionValidation.When(string.IsNullOrEmpty(state), "Invalid state. State is required");
        DomainExceptionValidation.When(state.Length < 4, "Invalid street, too short. Minimum 4 characters.");
        
        DomainExceptionValidation.When(string.IsNullOrEmpty(number), "Invalid number. Number is required");
        
        DomainExceptionValidation.When(string.IsNullOrEmpty(zipCode), "Invalid zip code. Zip Code is required");
        DomainExceptionValidation.When(!ValidateZipCode.IsZipCode(zipCode), "Invalid zip code. Incorrect Zip Code Format");

        Street = street;
        Neighborhood = neighborhood;
        City = city;
        State = state;
        Number = number;
        ZipCode = zipCode;
    }
    
   
    }
}