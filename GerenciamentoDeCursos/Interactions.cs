namespace GerenciamentoDeCursos;

public class UserInteractions
{
    public void ExibirMenuPrincipal()
    {
        Console.WriteLine($"    MAIN MENU\n---------------\n"+
        "1) Registrations\n"+
        "2) Enrollments\n"+
        "3) Deletions\n"+
        "4) Reports");
        Console.Write("Enter an option: ");
    }
    public void ExibirSubmenuCadastros()
    {
        Console.WriteLine($"   REGISTRATIONS\n-----------------\n"+
        "1) Register student\n"+
        "2) Register course\n"+
        "3) Back to main menu");
        Console.Write("Enter an option: ");
    }
    public void ExibirSubmenuEnrollments()
    {
        Console.WriteLine($"   REGISTRATIONS\n-----------------\n"+
        "1) Register student\n"+
        "2) Register course\n"+
        "3) Back to main menu");
        Console.Write("Enter an option: ");
    }

    public void ExibirSubmenuRelatorios()
    {
        Console.WriteLine($"   REPORTS\n-------------\n"+
        "1) List of students\n"+
        "2) List of courses\n"+
        "3) Enrollment reports\n"+
        "4) Back to main menu");
        Console.Write("Enter an option: ");
    }
    public void ExibirSubmenuExclusoes()
    {
        Console.WriteLine($"   EXCLUSIONS\n-----------------\n"+
        "1) Delete student\n"+
        "2) Delete course\n"+
        "3) Back to main menu");
        Console.Write("Enter an option: ");
    }
    public void NavigateMainMenu()
    {
        ExibirMenuPrincipal();
        string opcao = Console.ReadLine();

        switch(opcao)
        {
            case "1":
                //Call the navigation method for the REGISTRATIONS submenu
                break;
            case "2":
                //Call the navigation method for the registrations submenu
                break;
            case "3"

        }
    }
}
