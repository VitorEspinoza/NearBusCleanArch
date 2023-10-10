using FluentAssertions;
using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Domain.Tests;

public class EmployeeUnitTest1
{
    [Fact(DisplayName = "Throw Domain Exception For Missing Document")]
    public void CreateEmployee_MissingDocumentValue_DomainExceptionRequiredDocument()
    {
        Action action = () => new Employee(1, "Vitor", "");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid document. Document is required");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Null Document")]
    public void CreateEmployee_WithNullDocumentValue_DomainExceptionRequiredDocument()
    {
        Action action = () => new Employee(1, "Vitor", null);
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid document. Document is required");
    }
    
    [Fact(DisplayName = "Create Employee With Valid State")]
    public void CreateEmployee_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Employee(1, "Vitor", "863.803.810-07");
        action.Should()
            .NotThrow<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Invalid Id")]
    public void CreateEmployee_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Employee(-1, "Vitor", "863.803.810-07");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Too Short Name")]
    public void CreateEmployee_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Employee(1, "Vi", "863.803.810-07");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short. Minimum 3 characters.");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Missing Name")]
    public void CreateEmployee_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Employee(1, "", "863.803.810-07");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Null Name")]
    public void CreateEmployee_WithNullNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Employee(1, null, "863.803.810-07");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }
}