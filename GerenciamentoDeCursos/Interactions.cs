namespace GerenciamentoDeCursos;


public class UserInteractions
{
    // centralizes all menus that interact with the user
    public void StartPresentation()
    {
        Console.WriteLine("Welcome to the Courses Manegement Sistem");
        Console.WriteLine("===============================================");
        Console.WriteLine();
    }
    public void ShowMainMenu()
    {
        Console.WriteLine($"    MAIN MENU\n---------------\n" +
        "1) Registrations\n" +
        "2) Enrollments\n" +
        "3) Deletions\n" +
        "4) Reports");
        Console.Write("Enter an option: ");
    }
    public void ShowSubmenuRegistrations()
    {
        Console.WriteLine($"   REGISTRATIONS\n-----------------\n" +
        "1) Register student\n" +
        "2) Register course\n" +
        "3) Back to main menu");
        Console.Write("Enter an option: ");
    }
    public void ShowSubmenuEnrollments()
    {
        Console.WriteLine($"   ENROLLMENTS\n-----------------\n" +
        "1) Enroll a student\n" +
        "2) Withdraw a student\n" +
        "3) Back to main menu");
        Console.Write("Enter an option: ");
    }
    public void ShowSubmenuExclusions()
    {
        Console.WriteLine($"   EXCLUSIONS\n-----------------\n" +
        "1) Delete student\n" +
        "2) Delete course\n" +
        "3) Back to main menu");
        Console.Write("Enter an option: ");
    }
    public void ShowSubmenuReports()
    {
        Console.WriteLine($"   REPORTS\n-------------\n" +
        "1) List of students\n" +
        "2) List of courses\n" +
        "3) Enrollment reports\n" +
        "4) Back to main menu");
        Console.Write("Enter an option: ");
    }

    //Methods for navigating menus
    public void NavigateMainMenu(List<Student> students, List<Course> courses)
    {
        ShowMainMenu();
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                NavigateSubmenuRegistrations(students, courses);
                break;
            case "2":
                NavigateSubmenuEnrollments(students, courses);
                break;
            case "3":
                NavigateSubmenuExclusions(students, courses);
                break;
            case "4":
                NavigateSubmenuReports(students, courses);
                break;
            default:
                Console.WriteLine("Invalid Option. Please, try again!");
                NavigateMainMenu(students, courses);
                break;
        }
    }

    public void NavigateSubmenuRegistrations(List<Student> students, List<Course> courses)
    {
        ShowSubmenuRegistrations();
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                registrerList(students, Student.RegistrerStudent);
                break;
            case "2":
                registrerList(courses, Course.RegisterCourse);
                break;
            case "3":
                ShowMainMenu();
                NavigateMainMenu(students, courses);
                break;
            default:
                Console.WriteLine("Invalid Option. Please, try again!");
                NavigateSubmenuRegistrations(students, courses);
                break;
        }
    }
    public void NavigateSubmenuEnrollments(List<Student> students, List<Course> courses)
    {
        ShowSubmenuEnrollments();
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                // Chamar o método para matricular o aluno
                break;
            case "2":
                // Chamar o método para retirar a matrícula do aluno
                break;
            case "3":
                ShowMainMenu();
                NavigateMainMenu(students, courses);
                break;
            default:
                Console.WriteLine("Invalid Option. Please, try again!");
                NavigateSubmenuEnrollments(students, courses);
                break;
        }
    }
    public void NavigateSubmenuExclusions(List<Student> students, List<Course> courses)
    {
        ShowSubmenuExclusions();
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                // Chamar o método para deletar o aluno
                break;
            case "2":
                // Chamar o método para deletar o curso
                break;
            case "3":
                ShowMainMenu();
                NavigateMainMenu(students, courses);
                break;
            default:
                Console.WriteLine("Invalid Option. Please, try again!");
                NavigateSubmenuExclusions(students, courses);
                break;
        }
    }
    public void NavigateSubmenuReports(List<Student> students, List<Course> courses)
    {
        ShowSubmenuReports();
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                // Chamar o método para listar os alunos
                break;
            case "2":
                // Chamar o método para listar os cursos
                break;
            case "3":
                // Chamar o método para os relatórios de matrícula
                break;
            case "4":
                ShowMainMenu();
                NavigateMainMenu(students, courses);
                break;
            default:
                Console.WriteLine("Invalid Option. Please, try again!");
                NavigateSubmenuReports(students, courses);
                break;
        }
    }
    internal void registrerList<T>(List<T> list, Action<List<T>> registrerAction)
    {
        registrerAction(list);
    }
}
