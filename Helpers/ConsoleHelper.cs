namespace GerenciamentoDeCursos.Helpers
{
    public class ConsoleHelper
    {
        // Prints an error message in red
        public static void PrintError(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        // Prints a success message in green
        public static void PrintSuccess(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        // Prints a warning message in yellow
        public static void PrintWarning(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message);
            Console.ResetColor();
        }

        // Prints an informational message in cyan
        public static void PrintInfo(string message)
        {
            Console.ForegroundColor = ConsoleColor.Cyan; // Cyan color for informational messages
            Console.WriteLine(message);
            Console.ResetColor(); // Resets the console color to the default
        }
    }
}
