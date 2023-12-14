using System;
using System.Collections.Generic;
using System.Globalization;
using NearBusCleanArch.Domain.Validation;

namespace NearBusCleanArch.Domain.Entities;

public class Route : Entity
{
    public string Name { get; private set; }
    public TimeOnly DepartureTime { get; private set; }
    
    public DayOfWeek[] DepartureDays  { get; private set; } 
    
    
    public Route(string name, TimeOnly departureTime, DayOfWeek[] departureDays)
    {
        ValidateDomain(name, departureTime, departureDays);
    }

    public Route(int id, string name, TimeOnly departureTime,  DayOfWeek[] departureDays)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value"); 
        ValidateDomain(name, departureTime, departureDays);

    }

    public void Update(string name, TimeOnly departureTime,  DayOfWeek[] departureDays)
    {
        ValidateDomain(name, departureTime, departureDays);
    }
    private void ValidateDomain(string name, TimeOnly departureTime,  DayOfWeek[] departureDays)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short. Minimum 3 characters.");
        
        bool haveValidDay = departureDays.Any(dia => dia >= DayOfWeek.Sunday && dia <= DayOfWeek.Saturday);
        DomainExceptionValidation.When(!haveValidDay, "Invalid departure days. You must inform at least 1 valid day.");

       Console.WriteLine(departureTime + departureTime.ToString());
        Name = name;
        DepartureTime = departureTime;
        DepartureDays = departureDays;
    }

   
    public int CompanieId { get; set; }
    public Companie Companie { get; set; }

    public ICollection<Employee> Employees { get; } = new List<Employee>();

    private bool TimeOnlyIsValid(TimeOnly time)
    {
        return time.Hour >= 0 && time.Hour <= 23 && time.Minute >= 0 && time.Minute <= 59;
    }
}