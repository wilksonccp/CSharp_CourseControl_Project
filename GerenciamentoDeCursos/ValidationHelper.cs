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
        return age > 0 && age <= 120;
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
        return double.TryParse(input, out _);
    }
    //Check if imput is a letter
    public static bool IsAlphabetic(string input)
    {
        return input.All(char.IsLetter);
    }
    // Check if the input is a number (only integrer)
    public static bool IsNumeric(string input)
    {
        return input.All(char.IsDigit);
    }
    //check the number of characters in the description
    public static bool IsValidLength(string input, int maxLength)
    {
        return input.Length <= maxLength;
    }
    // checks if a student exists given an ID and returns true if it exists
    public static bool StudentExist(int Id, List<Student> students)
    {
        foreach (Student student in students)
        {
            if (student.Id == Id)
            {
                return true;
            }
        }
        return false;
    }
    // checks if a course exists given an ID and returns true if it exists
    public static bool CourseExist(int code, List<Course> courses)
    {
        foreach (Course course in courses)
        {
            if (course.Code == code)
            {
                return true;
            }
        }
        return false;
    }
    // Checks if a number of characters is the same length as required
    public static bool ValidateMinLength(string input, int minLenght)
    {
        return input.Length >= minLenght;
    }
    // Cheks if imput is empt or null.
    public static bool IsValidString(string input)
    {
        return !string.IsNullOrWhiteSpace(input);
    }


}
