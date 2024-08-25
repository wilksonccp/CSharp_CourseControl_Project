using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text.RegularExpressions;
namespace GerenciamentoDeCursos;

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
    public static bool IsUniqueId(int id, List<Student> stuentList)
    {
        return stuentList.All(student => student.Id != id);
    }
    //Checks if input is a number
    public static bool IsValidNumber(string input)
    {
        return int.TryParse(input, out _);
    }
    
}
