using System;
using System.Globalization;
using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace GerenciamentoDeCursos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /*Console.Title = "Sistema de Controle de Cursos";
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetWindowSize(50, 15);*/

            UserInteractions userInteractions = new UserInteractions();
            // Declaration of lists required for the program
            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();

            //Talk the main menu
            userInteractions.StartPresentation();
            userInteractions.NavigateMainMenu(students, courses);

        }
    }
}

