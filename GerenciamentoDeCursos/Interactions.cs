using System.IO.Pipes;

namespace GerenciamentoDeCursos;


public class UserInteractions
{
    //generic instantiation until implement the interaction loops
    Course temporaryCouse = new Course(00, "anyname", "anydescription", 999.99 );
    Student temporaryStudent = new Student( 00, "stuName", 99, "anyemail@gamil.com");
    Reports temporaryReport = new Reports( );
    
    // centralizes all menus that interact with the user
    public void StartPresentation()
    {
        Console.WriteLine("Welcome to the Courses Manegement Sistem");
        Console.WriteLine("===============================================");
        Console.WriteLine();
    }
    public void AndPresentation()
    {
        Console.WriteLine("Thank you for use the Course Manegemant Sistem");
        Console.WriteLine("===============================================");
        Console.WriteLine("Press any key to exit");
        Console.ReadLine();
    }
    public void ShowMainMenu()
    {
        Console.WriteLine($"    MAIN MENU\n---------------\n" +
        "1) Registrations\n" +
        "2) Enrollments\n" +
        "3) Exclusions\n" +
        "4) Reports\n" +
        "0) Exit");
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
            case "0":
                AndPresentation();
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
                ShowSubmenuRegistrations();
                break;
            case "2":
                registrerList(courses, Course.RegisterCourse);
                ShowSubmenuRegistrations();
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
                temporaryCouse.EnrollEstudent();
                ShowSubmenuEnrollments();
                break;
            case "2":
                // Chamar o método para retirar a matrícula do aluno
                temporaryCouse.UnenrollEstudent();
                ShowSubmenuEnrollments();
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
                temporaryStudent.DeleteStudent();
                ShowSubmenuExclusions();
                break;
            case "2":
                // Chamar o método para deletar o curso
                temporaryCouse.DeleteCourse();
                ShowSubmenuExclusions();
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
                temporaryReport.ListAllStudent();
                ShowSubmenuReports();
                break;
            case "2":
                // Chamar o método para listar os cursos
                temporaryReport.ListAllCourses();
                ShowSubmenuReports();
                break;
            case "3":
                // Chamar o método para os relatórios de matrícula
                temporaryReport.EnrollmentReports();
                ShowSubmenuReports();
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
