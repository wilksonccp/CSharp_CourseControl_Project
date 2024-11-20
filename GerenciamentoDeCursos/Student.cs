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
        string idInput = ValidationHelper.GetValidatedID("Enter the student ID: ", 3);
        int id = int.Parse(idInput);
        
        // Check if ID is unique
        while (!ValidationHelper.IsUnique(id, studentList, student => student.Id))
        {
            ConsoleHelper.PrintWarning("This ID is already in use. Please enter a unique ID: ");
            idInput = Console.ReadLine();
            id = int.Parse(idInput);
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
    public void DeleteStudent()
    {
        Console.Write("EnrollStudent method not implemented yet.");
        Console.Read();
    }

}
