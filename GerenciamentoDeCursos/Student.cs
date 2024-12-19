namespace GerenciamentoDeCursos;

public class Student
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Email { get; set; }

    public Student(int id, string name, int age, string email)
    {
        Id = id;
        Name = name;
        Age = age;
        Email = email;
    }
    //Method for inserting a student into the list
    public static void RegistrerStudent(List<Student> studentList)
    {
        Console.Clear();

        // Check if ID is entered correctly
        string IdStrig = ValidationHelper.GetValidatedID("Enter the student ID: ", 3);
        int id = int.Parse(IdStrig);

        // Check if ID is unique
        while (!ValidationHelper.IsUnique(id, studentList, student => student.Id))
        {
            ConsoleHelper.PrintWarning("This ID is already in use. Please enter a unique ID: ");
            IdStrig = ValidationHelper.GetValidatedID("Enter the student ID: ", 3);
            id = int.Parse(IdStrig);
        }

        // Check if name is correctly inserted
        string name;
        do
        {
            Console.Write("Enter the student name: ");
            name = Console.ReadLine();

            if (!ValidationHelper.IsValidString(name))
            {
                ConsoleHelper.PrintError("Error: The input cannot be empty.");
            }
            else if (!ValidationHelper.IsAlphabetic(name))
            {
                ConsoleHelper.PrintError("Error: The input must contain only letters.");
            }
            else if (!ValidationHelper.IsValidLength(name, 3, 70))
            {
                ConsoleHelper.PrintError("Error: The name's studente must be 3 to 70 characters long.");
            }
        } while (!ValidationHelper.IsValidString(name) || !ValidationHelper.IsAlphabetic(name) || !ValidationHelper.IsValidLength(name, 3, 70));


        // Check if age is correctly inserted
        string ageInput;
        do
        {
            Console.Write("Enter the student age: ");
            ageInput = Console.ReadLine();

            if (!ValidationHelper.IsValidString(ageInput))
            {
                ConsoleHelper.PrintError("Error: The input cannot be empty.");
            }
            else if (!ValidationHelper.IsNumeric(ageInput))
            {
                ConsoleHelper.PrintError("Error: The input must be a number.");
            }
            else if (!ValidationHelper.IsValidAge(int.Parse(ageInput), 4, 120))
            {
                ConsoleHelper.PrintError("Error: The age must be between 4 and 120.");
            }

        } while (!ValidationHelper.IsValidString(ageInput) || !ValidationHelper.IsNumeric(ageInput) || !ValidationHelper.IsValidAge(int.Parse(ageInput), 4, 120));

        int age = int.Parse(ageInput);

        // Check if e-mail is correctly inserted
        string email;
        do
        {
            Console.Write("Enter the student e-mail: ");
            email = Console.ReadLine();

            if (!ValidationHelper.IsValidString(email))
            {
                ConsoleHelper.PrintError("Error: The input cannot be empty.");
            }
            else if (!ValidationHelper.IsValidEmail(email))
            {
                ConsoleHelper.PrintError("Error: Invalid e-mail format.");
            }
            else if (!ValidationHelper.IsValidLength(email, 8, 80))
            {
                ConsoleHelper.PrintError("Error: The e-mail must be 8 to 80 characters long.");
            }
        } while (!ValidationHelper.IsValidString(email) || !ValidationHelper.IsValidEmail(email) || !ValidationHelper.IsValidLength(email, 8, 80));

        // Create a new instance and add to the list
        Student newStudent = new Student(id, name, age, email);
        studentList.Add(newStudent);

        ConsoleHelper.PrintSuccess("Student registered successfully!");
        Console.Read();
    }
    public static void DeleteStudent(List<Student> students, List<Course> courses)
    {
        ConsoleHelper.PrintInfo("=== Delete Student ===");

        // 1️⃣ Requests the student ID
        Student studentToRemove = null;

        while (studentToRemove == null)
        {
            // Calls the GetValidatedID function, which now accepts "exit" as input
            string studentIdString = ValidationHelper.GetValidatedID("Enter the Student ID to delete (or type 'exit' to cancel): ", 3);

            // Checks if the user typed "exit"
            if (studentIdString.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                ConsoleHelper.PrintInfo("You have chosen to exit the delete operation.");
                return; // Exits the method immediately
            }

            int studentId = int.Parse(studentIdString);
            studentToRemove = students.FirstOrDefault(student => student.Id == studentId);

            if (studentToRemove == null)
            {
                ConsoleHelper.PrintError("Student not found. Please enter a valid Student ID.");
            }
        }

        // 2️⃣ Verify if the student is enrolled in any course
        List<Course> enrolledCourses = courses.Where(course => course.Students.Any(s => s.Id == studentToRemove.Id)).ToList();

        if (enrolledCourses.Count > 0)
        {
            // Display the courses where the student is enrolled
            ConsoleHelper.PrintWarning("The student is enrolled in the following courses:");

            foreach (var course in enrolledCourses)
            {
                ConsoleHelper.PrintInfo($"- {course.Name}");
            }

            // Ask the user if they want to continue
            ConsoleHelper.PrintWarning("Do you want to remove this student from these courses and delete it? (Y/N)");
            string confirmation = Console.ReadLine().ToUpper();

            if (confirmation != "Y")
            {
                ConsoleHelper.PrintInfo("Operation canceled, press Enter.");
                Console.Read();
                return; // Exit the method if the user does not confirm the deletion

            }

            // Remove the student from all courses
            foreach (var course in enrolledCourses)
            {
                course.Students.RemoveAll(s => s.Id == studentToRemove.Id);
            }

            ConsoleHelper.PrintSuccess("All enrollments for this student have been removed.");
        }
        else
        {
            ConsoleHelper.PrintInfo("The student is not enrolled in any courses.");
        }

        // 3️⃣ Remove the student from the global list of students
        students.Remove(studentToRemove);
        ConsoleHelper.PrintSuccess("Student deleted successfully, press Enter to return to the menu.");
        Console.Read();
    }
}
