using System.Globalization;

namespace GerenciamentoDeCursos;

public class Course
{
    public int Code { get; private set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public List<Student> Students { get; } = new List<Student>();

    public Course(int code, string name, string description, double price)
    {
        Code = code;
        Name = name;
        Description = description;
        Price = price;
    }
    // TODO: mUDAR AS CORES DAS MENSAGESN DE ERRO PARA VERMELHO PARA MELHORAR A IDENTIFICAÇÃO DOS ERROS.
    // Method for registering a new course
    public static void RegisterCourse(List<Course> courseList)
    {
        Console.Clear();

        // Check if CODE is entered correctly
        string codeInput;
        do
        {
            Console.Write("Enter the course CODE: ");
            codeInput = Console.ReadLine();

            if (!ValidationHelper.IsValidString(codeInput))
            {
                Console.WriteLine("Error: The input cannot be empty.");
            }
            else if (!ValidationHelper.IsNumeric(codeInput))
            {
                Console.WriteLine("Error: The CODE must be numeric.");
            }
        } while (!ValidationHelper.IsValidString(codeInput) || !ValidationHelper.IsNumeric(codeInput));

        int code = int.Parse(codeInput);

        // Check if CODE is unique
        while (!ValidationHelper.IsUnique(code, courseList, course => course.Code))
        {
            Console.Write("This CODE is already in use. Please enter a unique CODE: ");
            codeInput = Console.ReadLine();
            code = int.Parse(codeInput);
        }

        // Check if name is correctly inserted
        string name;
        do
        {
            Console.Write("Enter the course name: ");
            name = Console.ReadLine();

            if (!ValidationHelper.IsValidString(name))
            {
                Console.WriteLine("Error: The input cannot be empty.");
            }
            else if (!ValidationHelper.IsAlphabetic(name))
            {
                Console.WriteLine("Error: The name must contain only letters.");
            }
        } while (!ValidationHelper.IsValidString(name) || !ValidationHelper.IsAlphabetic(name));

        // Check if description is correctly inserted
        string description;
        do
        {
            Console.Write("Enter the course description: ");
            description = Console.ReadLine();

            if (!ValidationHelper.IsValidString(description))
            {
                Console.WriteLine("Error: The input cannot be empty.");
            }
            else if (!ValidationHelper.IsAlphabetic(description))
            {
                Console.WriteLine("Error: The description must contain only letters.");
            }
            else if (!ValidationHelper.IsValidLength(description, 300))
            {
                Console.WriteLine("Error: The description must be 300 characters or less.");
            }
        } while (!ValidationHelper.IsValidString(description) || !ValidationHelper.IsAlphabetic(description) || !ValidationHelper.IsValidLength(description, 300));

        // Check if price is correctly inserted
        string priceInput;
        do
        {
            Console.Write("Enter the course price: ");
            priceInput = Console.ReadLine();

            if (!ValidationHelper.IsValidString(priceInput))
            {
                Console.WriteLine("Error: The input cannot be empty.");
            }
            else if (!ValidationHelper.IsValidNumber(priceInput))
            {
                Console.WriteLine("Error: The price must be a valid number.");
            }
        } while (!ValidationHelper.IsValidString(priceInput) || !ValidationHelper.IsValidNumber(priceInput));

        double price = double.Parse(priceInput, CultureInfo.InvariantCulture);

        // Creates a new Course instance with the entered data
        Course newCourse = new Course(code, name, description, price);
        courseList.Add(newCourse);

        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("Course registered successfully!");
        Console.ResetColor();
        Console.Read();
    }

    public void EnrollStudent(Student student)
    {
        if (!Students.Contains(student))
        {
            Students.Add(student);
        }
        else
        {
            Console.WriteLine("Student is already enrolled in this course.");
        }
    }

    public void UnenrollStudent(Student student)
    {
        if (Students.Contains(student))
        {
            Students.Remove(student);
            Console.WriteLine("Student unenrolled successfully.");
        }
        else
        {
            Console.WriteLine("Student is not enrolled in this course.");
        }
    }

    public void DeleteCourse()
    {
        Console.WriteLine("DeleteCourse method not implemented yet.");
    }
}
