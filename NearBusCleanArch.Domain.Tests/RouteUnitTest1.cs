using FluentAssertions;
using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Domain.Tests;

public class RouteUnitTest1
{

    [Fact(DisplayName = "Throw Domain Exception For Invalid Departure Time")]
    public void CreateRoute_WithInvalidDepartureTimeValue_DomainExceptionRequiredDepartureTime()
    {
        Action action = () => new Route(1, "Fake Route", new TimeSpan(-8, 0, 0), new DayOfWeek[] { DayOfWeek.Friday });
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Hour. The time has to be between 00:00 and 23:59");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Invalid Departure Days")]
    public void CreateRoute_WithInvalidDepartureDaysValue_DomainExceptionRequiredDepartureTime()
    {
        Action action = () => new Route(1, "Fake Route", new TimeSpan(-8, 0, 0), new DayOfWeek[] {});
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid departure days. You must inform at least 1 valid day.");
    }
    
    [Fact(DisplayName = "Create Route With Valid State")]
    public void CreateRoute_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Route(1, "Fake Route", new TimeSpan(8, 0, 0), new DayOfWeek[] { DayOfWeek.Friday });
        action.Should()
            .NotThrow<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Invalid Id")]
    public void CreateRoute_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Route(-1, "Fake Route", new TimeSpan(8, 0, 0), new DayOfWeek[] { DayOfWeek.Friday });
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Too Short Name")]
    public void CreateRoute_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Route(1, "vi", new TimeSpan(8, 0, 0), new DayOfWeek[] { DayOfWeek.Friday });
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short. Minimum 3 characters.");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Missing Name")]
    public void CreateRoute_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Route(1, "", new TimeSpan(8, 0, 0), new DayOfWeek[] { DayOfWeek.Friday });
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Null Name")]
    public void CreateRoute_WithNullNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Route(1, null, new TimeSpan(8, 0, 0), new DayOfWeek[] { DayOfWeek.Friday });
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }
}