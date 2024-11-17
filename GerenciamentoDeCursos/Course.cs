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
            else if (!ValidationHelper.IsValidLength(codeInput, 4, 4))
            {
                Console.WriteLine("Error: The CODE must be 4 characters long.");
            }
        } while (!ValidationHelper.IsValidString(codeInput) || !ValidationHelper.IsNumeric(codeInput) || !ValidationHelper.IsValidLength(codeInput, 4, 4));

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
            else if (!ValidationHelper.IsValidLength(name, 8, 70))
            {
                Console.WriteLine("Error: The name must be 8 to 70 characters long.");
            }
        } while (!ValidationHelper.IsValidString(name) || !ValidationHelper.IsAlphabetic(name) || !ValidationHelper.IsValidLength(name, 8, 70));

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
            else if (!ValidationHelper.IsValidLength(description, 10, 300))
            {
                Console.WriteLine("Error: The description must be 30 to 300 characters long.");
            }
        } while (!ValidationHelper.IsValidString(description) || !ValidationHelper.IsAlphabetic(description) || !ValidationHelper.IsValidLength(description, 10, 300));

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
            else if (!ValidationHelper.IsValidPrice(decimal.Parse(priceInput), 10.00m, 1500.00m))
            {
                Console.WriteLine("Error: The price must be between R$ 10,00 and R$ 1.500,00");
            }
        } while (!ValidationHelper.IsValidString(priceInput) || !ValidationHelper.IsValidNumber(priceInput) || !ValidationHelper.IsValidPrice(decimal.Parse(priceInput), 10.00m, 1500.00m));

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
