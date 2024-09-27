using System.Globalization;
using System.Runtime.CompilerServices;

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

    //Method for registering a new course
    public static void RegisterCourse(List<Course> courseList)
    {
        Console.Clear();
        Console.Write("Enter the CODE course: ");
        string codeInput = Console.ReadLine();

        //Check if inser is a number
        while (!ValidationHelper.IsValidNumber(codeInput))
        {
            Console.Write("Invalid input. Please enter a valid number for the CODE: ");
            codeInput = Console.ReadLine();
        }
        int code = int.Parse(codeInput);

        // Checks if ID is unique
        while (!ValidationHelper.IsUnique(code, courseList, course => course.Code))
        {
            Console.Write("This CODE is already in use. Please enter a unique ID: ");
            code = int.Parse(Console.ReadLine());
        }

        // Insert the name course
        Console.Write("Enter the course name: ");
        string name = Console.ReadLine();

        //inser the description course
        Console.Write("Enter the course description: ");
        string description = Console.ReadLine();

        //Check maximum description length
        while (!ValidationHelper.IsValidLength(description, 300))
        {
            Console.WriteLine("----------------------------------");
            Console.WriteLine("Enter a description with a\n maximum of 300 characters");
            description = Console.ReadLine();
        }

        Console.Write("Enter the course value: ");
        string priceImput = Console.ReadLine();

         while (!ValidationHelper.IsValidNumber(priceImput))
        {
            Console.Write("Invalid input. Please enter a valid number for the PRICE: ");
            priceImput = Console.ReadLine();
        }
        double price = double.Parse(codeInput, CultureInfo.InvariantCulture);

        //Creates a new Course instance with the entered data
        Course newCourse = new Course(code, name, description, price);
        courseList.Add(newCourse);

        Console.Write("Course registered successfully!");

    }
    public void EnrollStudent(Student student)
    {

        if (!Students.Contains(student))
        {
            Students.Add(student);
            Console.WriteLine("Student enrolled successfully!");
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
        Console.WriteLine("UnenrollStudent method not implemented yet.");
    }
}
