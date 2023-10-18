using System;
using System.Collections.Generic;
using System.Globalization;
using NearBusCleanArch.Domain.Validation;

namespace NearBusCleanArch.Domain.Entities;

public class Route : Entity
{
    public string Name { get; private set; }
    public TimeSpan DepartureTime { get; private set; }
    
    public DayOfWeek[] DepartureDays  { get; private set; } 
    
    
    public Route(string name, TimeSpan departureTime, DayOfWeek[] departureDays)
    {
        ValidateDomain(name, departureTime, departureDays);
    }

    public Route(int id, string name, TimeSpan departureTime,  DayOfWeek[] departureDays)
    {
        DomainExceptionValidation.When(id < 0, "Invalid Id value"); 
        ValidateDomain(name, departureTime, departureDays);

    }

    public void Update(string name, TimeSpan departureTime,  DayOfWeek[] departureDays)
    {
        ValidateDomain(name, departureTime, departureDays);
    }
    private void ValidateDomain(string name, TimeSpan departureTime,  DayOfWeek[] departureDays)
    {
        DomainExceptionValidation.When(string.IsNullOrEmpty(name), "Invalid name. Name is required");
        DomainExceptionValidation.When(name.Length < 3, "Invalid name, too short. Minimum 3 characters.");
        
        bool haveValidDay = departureDays.Any(dia => dia >= DayOfWeek.Sunday && dia <= DayOfWeek.Saturday);
        DomainExceptionValidation.When(!haveValidDay, "Invalid departure days. You must inform at least 1 valid day.");
        
        var validHour = departureTime.Hours >= 0 && departureTime.Hours <= 23;
        var validMinutes = departureTime.Minutes >= 0 && departureTime.Minutes <= 59;
        var validSeconds = departureTime.Seconds >= 0 && departureTime.Seconds <= 59;
        var invalidHour = !validHour || !validMinutes || !validSeconds;
        
        DomainExceptionValidation.When(invalidHour , "Invalid Hour. The time has to be between 00:00 and 23:59");
        
        Name = name;
        DepartureTime = departureTime;
        DepartureDays = departureDays;
    }

    public int CompanieId { get; set; }
    public Companie Companie { get; set; }

    public ICollection<Employee> Employees { get; } = new List<Employee>();

}