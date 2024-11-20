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
}
