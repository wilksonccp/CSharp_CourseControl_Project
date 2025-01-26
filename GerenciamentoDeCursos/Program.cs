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
            // Instantiate the UserInteractions class
            UserInteractions userInteractions = new UserInteractions();

            // Declaration of lists required for the program
            List<Student> students = new List<Student>();
            List<Course> courses = new List<Course>();

            // Start the main menu
            userInteractions.StartPresentation();
            
            // Navigate through the main menu
            userInteractions.NavigateMainMenu(students, courses);
        }
    }
}
