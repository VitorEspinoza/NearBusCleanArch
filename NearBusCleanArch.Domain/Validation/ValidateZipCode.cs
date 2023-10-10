namespace NearBusCleanArch.Domain.Validation;

public class ValidateZipCode
{
    public static bool IsZipCode(string zipCode)
    {
        System.Text.RegularExpressions.Regex zipCodeRegex = new System.Text.RegularExpressions.Regex("^[0-9]{5}-[0-9]{3}$");
        return zipCodeRegex.IsMatch(zipCode);
    }

}