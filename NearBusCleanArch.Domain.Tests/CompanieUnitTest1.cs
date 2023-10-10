using FluentAssertions;
using NearBusCleanArch.Domain.Entities;

namespace NearBusCleanArch.Domain.Tests;

public class CompanieUnitTest1
{
     [Fact(DisplayName = "Throw Domain Exception For Missing Document")]
    public void CreateCompanie_MissingDocumentValue_DomainExceptionRequiredDocument()
    {
        Action action = () => new Companie(1, "FakeCompanie", "");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid document. Document is required");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Null Document")]
    public void CreateCompanie_WithNullDocumentValue_DomainExceptionRequiredDocument()
    {
        Action action = () => new Companie(1, "FakeCompanie", null);
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid document. Document is required");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Invalid Document")]
    public void CreateCompanie_WithInvalidDocumentValue_DomainExceptionRequiredDocument()
    {
        Action action = () => new Companie(1, "FakeCompanie", "50859907000100");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid document.");
    }

    [Fact(DisplayName = "Create Companie With Valid State")]
    public void CreateCompanie_WithValidParameters_ResultObjectValidState()
    {
        Action action = () => new Companie(1, "FakeCompanie", "90185185000149");
        action.Should()
            .NotThrow<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>();
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Invalid Id")]
    public void CreateCompanie_NegativeIdValue_DomainExceptionInvalidId()
    {
        Action action = () => new Companie(-1, "FakeCompanie", "90185185000149");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid Id value");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Too Short Name")]
    public void CreateCompanie_ShortNameValue_DomainExceptionShortName()
    {
        Action action = () => new Companie(1, "Vi", "90185185000149");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name, too short. Minimum 3 characters.");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Missing Name")]
    public void CreateCompanie_MissingNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Companie(1, "", "90185185000149");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }
    
    [Fact(DisplayName = "Throw Domain Exception For Null Name")]
    public void CreateCompanie_WithNullNameValue_DomainExceptionRequiredName()
    {
        Action action = () => new Companie(1, null, "90185185000149");
        action.Should()
            .Throw<NearBusCleanArch.Domain.Validation.DomainExceptionValidation>()
            .WithMessage("Invalid name. Name is required");
    }
}