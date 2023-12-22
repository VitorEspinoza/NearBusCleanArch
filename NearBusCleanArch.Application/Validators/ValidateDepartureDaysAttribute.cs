using System.ComponentModel.DataAnnotations;

namespace NearBusCleanArch.Application.Validators;

public class ValidateDepartureDaysAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var departureDays = value as List<string>;

        if (departureDays == null || !departureDays.Any())
        {
            return new ValidationResult(ErrorMessage);
        }

        var validDays = new List<string>
        {
            "monday", "tuesday", "wednesday", "thursday", "friday", "saturday", "sunday"
        };

        var invalidDays = departureDays.Except(validDays, StringComparer.OrdinalIgnoreCase).ToList();

        if (invalidDays.Any())
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}
