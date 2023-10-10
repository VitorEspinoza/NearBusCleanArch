using System;
using System.Text;

namespace NearBusCleanArch.Domain.Validation;

public class ValidateCpf
{
    public static bool IsCpf(string cpf)
    {
        
        if (cpf.Length != 11)
        {
            return false;
        }
        
        if (AreAllDigitsSame(cpf))
        {
            return false;
        }
        
        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += int.Parse(cpf[i].ToString()) * (10 - i);
        }
        int firstVerificationDigit = 11 - (sum % 11);

        if (firstVerificationDigit >= 10)
        {
            firstVerificationDigit = 0;
        }
        
        sum = 0;
        for (int i = 0; i < 10; i++)
        {
            sum += int.Parse(cpf[i].ToString()) * (11 - i);
        }
        int secondVerificationDigit = 11 - (sum % 11);

        if (secondVerificationDigit >= 10)
        {
            secondVerificationDigit = 0;
        }
        
        return firstVerificationDigit == int.Parse(cpf[9].ToString()) &&
               secondVerificationDigit == int.Parse(cpf[10].ToString());
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