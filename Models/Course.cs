using System.Globalization;
using GerenciamentoDeCursos.Helpers;

namespace GerenciamentoDeCursos.Models
{


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
        // Method for registering a new course
        public static void RegisterCourse(List<Course> courseList)
        {
            Console.Clear();

            // Check if CODE is entered correctly
            string codeInput = ValidationHelper.GetValidatedID("Enter the course CODE: ", 4);
            int code = int.Parse(codeInput);

            // Check if CODE is unique
            while (!ValidationHelper.IsUnique(code, courseList, course => course.Code))
            {
                ConsoleHelper.PrintWarning("This CODE is already in use. Please enter a unique CODE: ");
                codeInput = ValidationHelper.GetValidatedID("Enter the course CODE: ", 4);
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
                    ConsoleHelper.PrintError("Error: The input cannot be empty.");
                }
                else if (!ValidationHelper.IsAlphabetic(name))
                {
                    ConsoleHelper.PrintError("Error: The name must contain only letters.");
                }
                else if (!ValidationHelper.IsValidLength(name, 8, 70))
                {
                    ConsoleHelper.PrintError("Error: The name must be 8 to 70 characters long.");
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
                    ConsoleHelper.PrintError("Error: The input cannot be empty.");
                }
                else if (!ValidationHelper.IsAlphabetic(description))
                {
                    ConsoleHelper.PrintError("Error: The description must contain only letters.");
                }
                else if (!ValidationHelper.IsValidLength(description, 30, 300))
                {
                    ConsoleHelper.PrintError("Error: The description must be 30 to 300 characters long.");
                }
            } while (!ValidationHelper.IsValidString(description) || !ValidationHelper.IsAlphabetic(description) || !ValidationHelper.IsValidLength(description, 10, 300));

            // Check if price is correctly inserted
            string priceInput;
            do
            {
                Console.Write("Enter the course price: ");
                priceInput = Console.ReadLine();
                priceInput = priceInput.Replace(',', '.');

                if (!ValidationHelper.IsValidString(priceInput))
                {
                    ConsoleHelper.PrintError("Error: The input cannot be empty.");
                }
                else if (!ValidationHelper.IsValidNumber(priceInput))
                {
                    ConsoleHelper.PrintError("Error: The price must be a valid number.");
                }
                else if (!ValidationHelper.IsValidPrice(decimal.Parse(priceInput), 10.00m, 1500.00m))
                {
                    ConsoleHelper.PrintError("Error: The price must be between R$ 10,00 and R$ 1.500,00");
                }
            } while (!ValidationHelper.IsValidString(priceInput) || !ValidationHelper.IsValidNumber(priceInput) || !ValidationHelper.IsValidPrice(decimal.Parse(priceInput), 10.00m, 1500.00m));

            double price = double.Parse(priceInput, CultureInfo.InvariantCulture);

            // Creates a new Course instance with the entered data
            Course newCourse = new Course(code, name, description, price);
            courseList.Add(newCourse);

            Console.ForegroundColor = ConsoleColor.Cyan;
            ConsoleHelper.PrintSuccess("Course registered successfully!");
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
                ConsoleHelper.PrintWarning("Student is already enrolled in this course.");
            }
        }

        public void UnenrollStudent(Student student)
        {
            if (Students.Contains(student))
            {
                Students.Remove(student);
            }
            else
            {
                ConsoleHelper.PrintWarning("Student is not enrolled in this course.");
            }
        }

        public static void DeleteCourse(List<Course> courses)
        {
            ConsoleHelper.PrintInfo("=== Delete Course ===");

            // 1️⃣ Request the course code
            Course courseToRemove = null;

            while (courseToRemove == null)
            {
                // Request the course code
                string courseCodeString = ValidationHelper.GetValidatedID("Enter the Course CODE to delete (or type 'exit' to cancel): ", 4);

                // Check if the user typed "exit"
                if (courseCodeString.Equals("exit", StringComparison.OrdinalIgnoreCase))
                {
                    ConsoleHelper.PrintInfo("You have chosen to exit the delete operation.");
                    ConsoleHelper.PrintInfo("Press ENTER");
                    Console.Read();
                    return; // Exit the method immediately
                }

                int courseCode = int.Parse(courseCodeString);

                // 2️⃣ Verify if the course exists
                courseToRemove = courses.FirstOrDefault(course => course.Code == courseCode);

                if (courseToRemove == null)
                {
                    ConsoleHelper.PrintError("Course not found. Please enter a valid Course CODE.");
                }
            }

            // 3️⃣ Verify if the course has enrolled students
            if (courseToRemove.Students.Count > 0)
            {
                ConsoleHelper.PrintWarning("It is not possible to delete this course because it has enrolled students.");
                ConsoleHelper.PrintWarning("Unenroll students before deleting the course.");

                // Display the list of enrolled students
                ConsoleHelper.PrintError("The following students are enrolled in this course:");
                foreach (var student in courseToRemove.Students)
                {
                    ConsoleHelper.PrintInfo($"- ID: {student.Id}, Name: {student.Name}");
                }
                ConsoleHelper.PrintInfo("Press ENTER");
                Console.Read();

                return; // Exit the method without deleting the course
            }

            // 4️⃣ Remove the course from the global course list
            courses.Remove(courseToRemove);
            ConsoleHelper.PrintSuccess("Course successfully deleted.");
            ConsoleHelper.PrintInfo("Press ENTER");
            Console.Read();
        }

        public bool IsStudentEnrolled(Student student)
        {
            return Students.Contains(student);
        }

    }

}