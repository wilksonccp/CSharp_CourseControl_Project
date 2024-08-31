namespace GerenciamentoDeCursos;

public class UserInteractions
{
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

    public void NavigateMainMenu()
    {
        ShowMainMenu();
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                // Chamar o método de navegação para o submenu REGISTRATIONS
                break;
            case "2":
                // Chamar o método de navegação para o submenu ENROLLMENTS
                break;
            case "3":
                // Chamar o método de navegação para o submenu EXCLUSIONS
                break;
            case "4":
                // Chamar o método de navegação para o submenu REPORTS
                break;
            default:
                Console.WriteLine("Invalid Option. Please, try again!");
                NavigateMainMenu();
                break;
        }
    }
    public void NavigateSubmenuRegistrations()
    {
        ShowSubmenuRegistrations();
        string opcao = Console.ReadLine();

        switch (opcao)
        {
            case "1":
                // Chamar o método para registrar o aluno
                break;
            case "2":
                // Chamar o método para registrar o curso
                break;
            case "3":
                ShowMainMenu();
                NavigateMainMenu();
                break;
            default:
                Console.WriteLine("Invalid Option. Please, try again!");
                NavigateSubmenuRegistrations();
                break;
        }
    }
    public void NavigateSubmenuEnrollments()
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
                NavigateMainMenu();
                break;
            default:
                Console.WriteLine("Invalid Option. Please, try again!");
                NavigateSubmenuEnrollments();
                break;
        }
    }
    public void NavigateSubmenuExclusions()
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
                NavigateMainMenu();
                break;
            default:
                Console.WriteLine("Invalid Option. Please, try again!");
                NavigateSubmenuExclusions();
                break;
        }
    }
    public void NavigateSubmenuReports()
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
                NavigateMainMenu();
                break;
            default:
                Console.WriteLine("Invalid Option. Please, try again!");
                NavigateSubmenuReports();
                break;
        }
    }
}
