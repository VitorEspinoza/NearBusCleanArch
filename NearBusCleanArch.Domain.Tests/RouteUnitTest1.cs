using FluentAssertions;
using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Domain.Tests;

public class RouteUnitTest1
{
     [Fact(DisplayName = "Throw Domain Exception For Missing Departure Time")]
    public void CreateRoute_MissingDepartureTime_DomainExceptionRequiredDepartureTime()
    {
        Action action = () => new Route(1, "Fake Route", "");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid date. Date is required");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Null Departure Time")]
    public void CreateRoute_WithNullDepartureTimeValue_DomainExceptionRequiredDepartureTime()
    {
        Action action = () => new Route(1, "Fake Route", null);
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid date. Date is required");
    }
    
    [Fact(DisplayName = "Create Route With Valid State")]
    public void CreateRoute_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Route(1, "Fake Route", "09/10/2023");
        action.Should()
            .NotThrow<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Invalid Id")]
    public void CreateRoute_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Route(-1, "Fake Route", "09/10/2023");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Too Short Name")]
    public void CreateRoute_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Route(1, "Vi", "09/10/2023");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short. Minimum 3 characters.");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Missing Name")]
    public void CreateRoute_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Route(1, "", "09/10/2023");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Null Name")]
    public void CreateRoute_WithNullNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Route(1, null, "09/10/2023");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }
}