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
        Console.Write("Enter the student ID:");

        string idInput = Console.ReadLine();

        // Checks if insert is a number
        while (!ValidationHelper.IsValidNumber(idInput))
        {
            Console.Write("Invalid input. Please enter a valid number for the ID: ");
            idInput = Console.ReadLine();
        }
        int id = int.Parse(idInput);

        // Checks if ID is unique
        
        while (!ValidationHelper.IsUnique(id, studentList, student => student.Id))
        {
            Console.Write("This Id is already in use. Please enter a unique ID: ");
            id = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter the student name: ");
        string name = Console.ReadLine();

        Console.Write("Enter the student age: ");
        string ageInput = Console.ReadLine();
        // Checks if insert is a number
        while (!ValidationHelper.IsValidNumber(ageInput) || !ValidationHelper.IsValidAge(int.Parse(ageInput)))
        {
            Console.Write("Invalid input. Please enter a valid age: ");
            ageInput = Console.ReadLine();
        }

        int age = int.Parse(ageInput);
        while (!ValidationHelper.IsValidAge(age))
        {
            Console.Write("Invalid age. Please enter a valid age: ");
            age = int.Parse(Console.ReadLine());
        }

        Console.Write("Enter the student e-mail: ");
        string email = Console.ReadLine();

        while (!ValidationHelper.IsValidEmail(email))
        {
            Console.Write("Invalid format e-mail. Please enter a valid email: ");
            email = Console.ReadLine();
        }

        //Creates a new Student instance with the entered data
        Student newStudent = new Student(id, name, age, email);
        studentList.Add(newStudent);

        Console.Write("Student registered successfully!");
    }
    public void DeleteStudent()
    {
        Console.Write("EnrollStudent method not implemented yet.");
        Console.Read();
    }
    
}
