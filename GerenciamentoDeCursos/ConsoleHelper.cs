namespace GerenciamentoDeCursos;

public class ConsoleHelper
{
    public static void PrintError(string message)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void PrintSuccess(string message)
    {
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine(message);
        Console.ResetColor();
    }

    public static void PrintWarning(string message)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;
        Console.WriteLine(message);
        Console.ResetColor();
    }
    public static void PrintInfo(string message)
    {
        Console.ForegroundColor = ConsoleColor.Cyan; // Cor ciano para informações
        Console.WriteLine(message);
        Console.ResetColor(); // Restaura a cor padrão do console
    }

}
