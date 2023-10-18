namespace NearBusCleanArch.Domain.Validation;

public class ValidateCnpj
{
    public static bool IsCnpj(string cnpj)
    {
        
        if (cnpj.Length != 14)
        {
            return false;
        }
        
        if (AreAllDigitsSame(cnpj))
        {
            return false;
        }
        
        int sum = 0;
        for (int i = 0; i < 12; i++)
        {
            int multiplier = (i < 4) ? 5 - i : 13 - i;
            sum += int.Parse(cnpj[i].ToString()) * multiplier;
        }
        int firstVerificationDigit = 11 - (sum % 11);

        if (firstVerificationDigit >= 10)
        {
            firstVerificationDigit = 0;
        }
        
        sum = 0;
        for (int i = 0; i < 13; i++)
        {
            int multiplier = (i < 5) ? 6 - i : 14 - i;
            sum += int.Parse(cnpj[i].ToString()) * multiplier;
        }
        int secondVerificationDigit = 11 - (sum % 11);

        if (secondVerificationDigit >= 10)
        {
            secondVerificationDigit = 0;
        }
        
        return firstVerificationDigit == int.Parse(cnpj[12].ToString()) &&
               secondVerificationDigit == int.Parse(cnpj[13].ToString());
    }

    private static bool AreAllDigitsSame(string input)
    {
        char firstDigit = input[0];

        foreach (char digit in input)
        {
            if (digit != firstDigit)
            {
                return false;
            }
        }

        return true;
    }

}