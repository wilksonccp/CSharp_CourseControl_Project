using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
namespace GerenciamentoDeCursos;

// all validations are here
public class ValidationHelper
{
    //Validates age
    public static bool IsValidAge(int age)
    {
        return age >= 0 && age <= 120;
    }
    // Validate e-mail
    public static bool IsValidEmail(string email)
    {
        // Simple regular expression to validate email format
        var emailPattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
        return Regex.IsMatch(email, emailPattern);
    }
    // Validate unique ID
    public static bool IsUnique<T>(int value, List<T> List, Func<T, int> selector)
    {
        return List.All(item => selector(item) != value);
    }
    //Checks if input is a number
    public static bool IsValidNumber(string input)
    {
        return int.TryParse(input, out _);
    }
    //check the number of characters in the description
    public static bool IsValidLength(string input, int maxLength)
    {
        return input.Length <= maxLength;
    }
    
}
