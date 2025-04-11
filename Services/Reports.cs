using GerenciamentoDeCursos.Helpers;
using GerenciamentoDeCursos.Models;

namespace GerenciamentoDeCursos.Services
{

    public class Reports
    {
        // Students Report
        public static void PrintStudentReport(List<Student> students, List<Course> courses)
        {
            ConsoleHelper.PrintInfo("=== Student Report ===");

            // Check if there are no students in the system
            if (students.Count == 0)
            {
                ConsoleHelper.PrintWarning("No students are registered in the system.");
                return;
            }

            // Iterate through the list of students
            foreach (var student in students)
            {
                ConsoleHelper.PrintInfo($"ID: {student.Id}, Name: {student.Name}, Age: {student.Age}");

                // Search for all courses where the student is enrolled
                var studentCourses = courses.Where(course => course.Students.Any(s => s.Id == student.Id)).ToList();

                if (studentCourses.Count > 0)
                {
                    // List the names of the courses the student is enrolled in
                    Console.WriteLine("Courses enrolled: " + string.Join(", ", studentCourses.Select(c => c.Name)));
                }
                else
                {
                    ConsoleHelper.PrintWarning("This student is not enrolled in any courses.");
                }

                // Separator for better readability
                Console.WriteLine("-------------------------------------------------");
            }

            // Prompt user to press ENTER before exiting
            ConsoleHelper.PrintInfo("Press ENTER");
            Console.Read();
        }

        // Courses Report
        public static void PrintCourseReport(List<Course> courses)
        {
            ConsoleHelper.PrintInfo("=== Course Report ===");

            // Check if there are no courses in the system
            if (courses.Count == 0)
            {
                ConsoleHelper.PrintWarning("No courses are registered in the system.");
                return;
            }

            // Iterate through the list of courses
            foreach (var course in courses)
            {
                // Display course details, including code, name, price, and the number of enrolled students
                ConsoleHelper.PrintInfo($"CODE: {course.Code}, Name: {course.Name}, Price: {course.Price:C}, Students Enrolled: {course.Students.Count}");

                // Separator for better readability
                Console.WriteLine("-------------------------------------------------");
            }

            // Prompt user to press ENTER before exiting
            ConsoleHelper.PrintInfo("Press ENTER");
            Console.Read();
        }

        // 3️⃣ Enrollment Report
        public static void PrintEnrollmentReport(List<Course> courses)
        {
            ConsoleHelper.PrintInfo("=== Enrollment Report ===");

            // Check if there are no courses in the system
            if (courses.Count == 0)
            {
                ConsoleHelper.PrintWarning("No courses are registered in the system.");
                return;
            }

            // Iterate through the list of courses
            foreach (var course in courses)
            {
                // Display course name and code
                ConsoleHelper.PrintInfo($"Course: {course.Name} (CODE: {course.Code})");

                // Check if there are no students enrolled in the course
                if (course.Students.Count == 0)
                {
                    ConsoleHelper.PrintWarning("No students are enrolled in this course.");
                }
                else
                {
                    // Display the list of enrolled students
                    Console.WriteLine("Students enrolled:");
                    foreach (var student in course.Students)
                    {
                        // Display student ID and name
                        ConsoleHelper.PrintInfo($"- ID: {student.Id}, Name: {student.Name}");
                    }
                }

                // Separator for better readability
                Console.WriteLine("-------------------------------------------------");
            }

            // Prompt user to press ENTER before exiting
            ConsoleHelper.PrintInfo("Press ENTER");
            Console.Read();
        }
    }

}