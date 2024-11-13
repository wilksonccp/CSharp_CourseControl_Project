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
    string idInput;
   do
{
    Console.Write("Enter the student ID: ");
    idInput = Console.ReadLine();

    if (!ValidationHelper.IsValidString(idInput))
    {
        Console.WriteLine("Error: The input cannot be empty.");
    }
    else if (!ValidationHelper.IsNumeric(idInput))
    {
        Console.WriteLine("Error: The input must contain only numbers.");
    }

} while (!ValidationHelper.IsValidString(idInput) || !ValidationHelper.IsNumeric(idInput));


    
    int id = int.Parse(idInput);

    // Check if ID is unique
    while (!ValidationHelper.IsUnique(id, studentList, student => student.Id))
    {
        Console.Write("This ID is already in use. Please enter a unique ID: ");
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
        Console.WriteLine("Error: The input cannot be empty.");
    }
    else if (!ValidationHelper.IsAlphabetic(name))
    {
        Console.WriteLine("Error: The input must contain only letters.");
    }

} while (!ValidationHelper.IsValidString(name) || !ValidationHelper.IsAlphabetic(name));


    // Check if age is correctly inserted
    string ageInput;
do
{
    Console.Write("Enter the student age: ");
    ageInput = Console.ReadLine();

    if (!ValidationHelper.IsValidString(ageInput))
    {
        Console.WriteLine("Error: The input cannot be empty.");
    }
    else if (!ValidationHelper.IsNumeric(ageInput))
    {
        Console.WriteLine("Error: The input must be a number.");
    }
    else if (!ValidationHelper.IsValidAge(int.Parse(ageInput)))
    {
        Console.WriteLine("Error: The age must be between 1 and 120.");
    }

} while (!ValidationHelper.IsValidString(ageInput) || !ValidationHelper.IsNumeric(ageInput) || !ValidationHelper.IsValidAge(int.Parse(ageInput)));

int age = int.Parse(ageInput);

    // Check if e-mail is correctly inserted
    string email;
do
{
    Console.Write("Enter the student e-mail: ");
    email = Console.ReadLine();

    if (!ValidationHelper.IsValidString(email))
    {
        Console.WriteLine("Error: The input cannot be empty.");
    }
    else if (!ValidationHelper.IsValidEmail(email))
    {
        Console.WriteLine("Error: Invalid e-mail format.");
    }

} while (!ValidationHelper.IsValidString(email) || !ValidationHelper.IsValidEmail(email));

    // Create a new instance and add to the list
    Student newStudent = new Student(id, name, age, email);
    studentList.Add(newStudent);

    Console.ForegroundColor = ConsoleColor.Cyan;
    Console.WriteLine("Student registered successfully!");
    Console.ResetColor();
    Console.Read();
}
    public void DeleteStudent()
    {
        Console.Write("EnrollStudent method not implemented yet.");
        Console.Read();
    }

}
