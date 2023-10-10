using System;
using System.Collections.Generic;
using System.Globalization;
using NearBusCleanArch.Domain.Validation;

namespace NearBusCleanArch.Domain.Entities;

public class Route : Entity
{
    public string Name { get; private set; }
    public DateTime DepartureTime { get; private set; }

    
    public Route(string name, string departureTime)
    {
        ValidateDomain(name, departureTime);
    }

    public Route(int id, string name, string departureTime)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value"); 
        ValidateDomain(name, departureTime);

    }

    public void Update(string name, string departureTime)
    {
        ValidateDomain(name, departureTime);
    }
    private void ValidateDomain(string name, string departureTime)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short. Minimum 3 characters.");
            
        DomainExceptionValidation.When(string.IsNullOrEmpty(departureTime), "Invalid date. Date is required");
        DateTime date;
        DomainExceptionValidation.When(!DateTime.TryParse(departureTime, out date), "Invalid date. Incorrect date format");

        Name = name;
        DepartureTime = date;
    }

    public int CompanieId { get; set; }
    public Companie Companie { get; set; }

    public ICollection<Employee> Employees { get; } = new List<Employee>();

}