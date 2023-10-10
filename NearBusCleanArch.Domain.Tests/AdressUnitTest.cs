using FluentAssertions;
using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Domain.Tests;

public class AdressUnitTest
{
     [Fact(DisplayName = "Throw Domain Exception For Missing Street")]
    public void CreateAdress_MissingStreetValue_DomainExceptionRequiredStreet()
    {
        Action action = () => new Adress(1, "", "fake neighborhood", "fake cityyy", "fake state", "232", "83608-070");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid street. Street is required");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Null Street")]
    public void CreateAdress_WithNullStreetValue_DomainExceptionRequiredStreet()
    {
        Action action = () => new Adress(1, null, "fake neighborhood", "fake cityyy", "fake state", "232", "83608-070");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid street. Street is required");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Too Short Street")]
    public void CreateAdress_ShortStreetValue_DomainExceptionShortStreet()
    {
        Action action = () => new Adress(1, "test", "fake neighborhood", "fake cityyy", "fake state", "232", "83608-070");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid street, too short. Minimum 10 characters.");
    }

    [Fact(DisplayName = "Throw Domain Exception For Missing Neighborhood")]
    public void CreateAdress_MissingNeighborhoodValue_DomainExceptionRequiredNeighborhood()
    {
        Action action = () => new Adress(1, "fake street", "", "fake cityyy", "fake state", "232", "83608-070");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid neighborhood. Neighborhood is required");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Null Neighborhood")]
    public void CreateAdress_WithNullNeighborhoodValue_DomainExceptionRequiredNeighborhood()
    {
        Action action = () => new Adress(1, "fake street", null, "fake cityyy", "fake state", "232", "83608-070");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid neighborhood. Neighborhood is required");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Too Short Neighborhood")]
    public void CreateAdress_ShortStreetValue_DomainExceptionShortNeighborhood()
    {
        Action action = () => new Adress(1, "fake street", "test", "fake cityyy", "fake state", "232", "83608-070");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid neighborhood, too short. Minimum 5 characters.");
    }

    
    [Fact(DisplayName = "Throw Domain Exception For Missing City")]
    public void CreateAdress_MissingCityValue_DomainExceptionRequiredCity()
    {
        Action action = () => new Adress(1, "fake street", "fake neighborhood", "", "fake state", "232", "83608-070");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid city. City is required");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Null City")]
    public void CreateAdress_WithNullCityValue_DomainExceptionRequiredCity()
    {
        Action action = () => new Adress(1, "fake street", "fake neighborhood", null, "fake state", "232", "83608-070");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid city. City is required");
    }

    [Fact(DisplayName = "Throw Domain Exception For Too Short City")]
    public void CreateAdress_ShortStreetValue_DomainExceptionShortCity()
    {
        Action action = () => new Adress(1, "fake street", "fake neighborhood", "t", "fake state", "232", "83608-070");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid city, too short. Minimum 2 characters.");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Missing State")]
    public void CreateAdress_MissingStateValue_DomainExceptionRequiredState()
    {
        Action action = () => new Adress(1, "fake street", "fake neighborhood", "fake cityyy", "", "232", "83608-070");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid state. State is required");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Null State")]
    public void CreateAdress_WithNullStateValue_DomainExceptionRequiredState()
    {
        Action action = () => new Adress(1, "fake street", "fake neighborhood", "fake cityyy", null, "232", "83608-070");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid state. State is required");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Too Short State")]
    public void CreateAdress_ShortStreetValue_DomainExceptionShortState()
    {
        Action action = () => new Adress(1, "fake street", "fake neighborhood", "fake city", "f", "232", "83608-070");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid state, too short. Minimum 4 characters.");
    }
    [Fact(DisplayName = "Throw Domain Exception For Missing Number")]
    public void CreateAdress_MissingNumberValue_DomainExceptionRequiredNumber()
    {
        Action action = () => new Adress(1, "fake street", "fake neighborhood", "fake cityyy", "fake state", "", "83608-070");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid number. Number is required");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Null Number")]
    public void CreateAdress_WithNullNumberValue_DomainExceptionRequiredNumber()
    {
        Action action = () => new Adress(1, "fake street", "fake neighborhood", "fake cityyy", "fake state", null, "83608-070");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid number. Number is required");
    }


    
    [Fact(DisplayName = "Create Adress With Valid State")]
    public void CreateAdress_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Adress(1, "fake street", "fake neighborhood", "fake cityyy", "fake state", "232", "83608-070");
        action.Should()
            .NotThrow<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Invalid Id")]
    public void CreateAdress_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Adress(-1, "fake street", "fake neighborhood", "fake cityyy", "fake state", "232", "83608-070");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }
    
    
    [Fact(DisplayName = "Throw Domain Exception For Invalid Zip Code")]
    public void CreateAdress_WithInvalidZipCode_DomainExceptionInvalidZipCode()
    {
        Action action = () => new Adress(1, "fake street", "fake neighborhood", "fake cityyy", "fake state", "232", "8360870");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid zip code. Incorrect Zip Code Format");
    }
}