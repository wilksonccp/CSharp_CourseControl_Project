using System.IO.Pipes;
using System.Reflection.Metadata;

namespace GerenciamentoDeCursos;


public class UserInteractions
{
    //FIXME: generic instantiation until implement the interaction loops
    Course temporaryCouse = new Course(00, "anyname", "anydescription", 999.99);
    Student temporaryStudent = new Student(00, "stuName", 99, "anyemail@gamil.com");
    Reports temporaryReport = new Reports();

    // centralizes all menus that interact with the user
    public void StartPresentation()
    {
        Console.WriteLine("""
        Welcome to the Courses Manegement Sistem
        ========================================
        PRESS ENTER KEY TO CONTINUE
        """);
        Console.Read();
        Console.Clear();
    }
    public void AndPresentation()
    {
        Console.Clear();
        Console.WriteLine("""
        Thank you for use the Course Manegemant Sistem
        ==============================================
        Press any key to exit
        """);
        Console.ReadLine();
    }
    public void ShowMainMenu()
    {
        Console.Clear();
        Console.WriteLine("""
            MAIN MENU
        -----------------
        1) Registrations
        2) Enrollments
        3) Exclusions
        4) Reports
        0) Exit
        """);
        Console.Write("Enter an option: ");
    }
    public void ShowSubmenuRegistrations()
    {
        Console.Clear();
        Console.WriteLine("""
          REGISTRATIONS
        -----------------
        1) Register student
        2) Register course
        3) Back to main menu
        """);
        Console.Write("Enter an option: ");
    }
    public void ShowSubmenuEnrollments()
    {

        Console.Clear();
        Console.WriteLine("""
           ENROLLMENTS
        -----------------
        1) Enroll a student
        2) Withdraw a student
        3) Back to main menu
        """);
        Console.Write("Enter an option: ");
    }
    public void ShowSubmenuExclusions()
    {
        Console.Clear();
        Console.WriteLine("""
            EXCLUSIONS
        -----------------
        1) Delete student
        2) Delete course
        3) Back to main menu
        """);
        Console.Write("Enter an option: ");
    }
    public void ShowSubmenuReports()
    {
        Console.Clear();
        Console.WriteLine("""
             REPORTS
        ------------------
        1) List of students
        2) List of courses
        3) Enrollment reports
        4) Back to main menu
        """);
        Console.Write("Enter an option: ");
    }

    //Methods for navigating menus
    public void NavigateMainMenu(List<Student> students, List<Course> courses)
    {
        bool running = true;
        while (running)
        {
            ShowMainMenu();
            string option1 = Console.ReadLine();
            switch (option1)
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
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid Option. Please, try again!");
                    break;
            }
        }
    }
    public void NavigateSubmenuRegistrations(List<Student> students, List<Course> courses)
    {
        bool running = true;
        while (running)
        {
            ShowSubmenuRegistrations();
            string option2 = Console.ReadLine();
            switch (option2)
            {
                case "1":
                    HandleListAction(students, Student.RegistrerStudent);
                    break;
                case "2":
                    HandleListAction(courses, Course.RegisterCourse);
                    break;
                case "3":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid Option. Please, try again!");
                    break;
            }
        }
    }
    public void NavigateSubmenuEnrollments(List<Student> students, List<Course> courses)
    {
        bool running = true;
        while (running)
        {
            ShowSubmenuEnrollments();
            string option3 = Console.ReadLine();
            switch (option3)
            {
                case "1":
                    // enroll student
                    EnrollStudent(students, courses);
                    break;
                case "2":
                    // unenroll student
                    UnenrollStudent(students, courses);
                    break;
                case "3":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid Option. Please, try again!");
                    break;
            }
        }
    }
    public void NavigateSubmenuExclusions(List<Student> students, List<Course> courses)
    {
        bool running = true;
        while (running)
        {
            ShowSubmenuExclusions();
            string option4 = Console.ReadLine();

            switch (option4)
            {
                case "1": // Exclusão de Estudante
                    HandleTwoListAction(students, courses, (list1, list2) =>
                    {
                        Student.DeleteStudent(list1, list2);
                    });
                    break;

                case "2": // Exclusão de Curso
                    HandleTwoListAction(courses, students, (list1, list2) =>
                    {
                        //Course.DeleteCourse(list1, list2);
                    });
                    break;

                case "3": // Sair do Submenu
                    running = false;
                    break;

                default:
                    ConsoleHelper.PrintError("Invalid Option. Please, try again!");
                    break;
            }
        }
    }
    public void NavigateSubmenuReports(List<Student> students, List<Course> courses)
    {
        bool running = true;
        while (running)
        {
            ShowSubmenuReports();
            string option5 = Console.ReadLine();
            switch (option5)
            {
                case "1":
                    // TODO: builder this method
                    temporaryReport.ListAllStudent();
                    break;
                case "2":
                    // TODO: builder this method
                    temporaryReport.ListAllCourses();
                    break;
                case "3":
                    // TODO: builder this method
                    temporaryReport.EnrollmentReports();
                    break;
                case "4":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid Option. Please, try again!");
                    break;
            }
        }
    }

    // complementary functions
    internal void HandleTwoListAction<T1, T2>(List<T1> list1, List<T2> list2, Action<List<T1>, List<T2>> action)
    {
        action(list1, list2);
    }
    internal void HandleListAction<T>(List<T> list, Action<List<T>> action)
    {
        action(list);
    }




    public void EnrollStudent(List<Student> students, List<Course> courses)
    {
        Console.Clear();

        // Ask and validate the student ID
        string studentInput;
        int studentId;
        do
        {
            studentInput = ValidationHelper.GetValidatedID("Enter the student ID (or 'exit' to return to the menu): ", 3);

            // Check for exit command
            if (studentInput == "exit")
            {
                ConsoleHelper.PrintInfo("Returning to the enrollment menu...(press enter)");
                Console.ReadLine();
                return; // Retorna ao menu de matrículas
            }

            if (!int.TryParse(studentInput, out studentId) || !ValidationHelper.StudentExist(studentId, students))
            {
                ConsoleHelper.PrintError("This ID doesn't exist. Please insert an existing student ID.");
            }
            else
            {
                break; // Exit loop when valid
            }
        } while (true);

        // Ask and validate the course CODE
        string courseInput;
        int courseCode;
        do
        {
            courseInput = ValidationHelper.GetValidatedID("Enter the course code (or 'exit' to return to the menu): ", 4);

            // Check for exit command
            if (courseInput.Equals("exit", StringComparison.OrdinalIgnoreCase))
            {
                ConsoleHelper.PrintInfo("Exiting enrollment menu...");
                return; // Exit the function
            }

            if (!int.TryParse(courseInput, out courseCode) || !ValidationHelper.CourseExist(courseCode, courses))
            {
                ConsoleHelper.PrintError("This CODE doesn't exist. Please insert an existing course CODE.");
            }
            else
            {
                break; // Exit loop when valid
            }
        } while (true);

        // Find the student and the course
        Student selectedStudent = students.First(s => s.Id == studentId);
        Course selectedCourse = courses.First(c => c.Code == courseCode);

        // Checks if the student is already enrolled
        if (selectedCourse.IsStudentEnrolled(selectedStudent))
        {
            ConsoleHelper.PrintError($"Student {selectedStudent.Name} is already enrolled in {selectedCourse.Name}.");
            return; // Exit the function
        }

        // Enroll the student
        selectedCourse.EnrollStudent(selectedStudent);
        ConsoleHelper.PrintSuccess($"Student {selectedStudent.Name} has been enrolled in {selectedCourse.Name}.");
        Console.Read();
    }
    public void UnenrollStudent(List<Student> students, List<Course> courses)
    {
        Console.Clear();

        // Ask and validate the student ID
        string studentInput = ValidationHelper.GetValidatedID("Enter the student ID: ", 3);
        int studentId = int.Parse(studentInput);

        if (!ValidationHelper.StudentExist(studentId, students))
        {
            ConsoleHelper.PrintError("This ID doesn't exist. Please insert an existing student ID.");
            return; // Exit the function
        }

        // Ask and validade the couse CODE
        string courseInput = ValidationHelper.GetValidatedID("Enter the course code: ", 4);
        int courseCode = int.Parse(courseInput);

        if (!ValidationHelper.CourseExist(courseCode, courses))
        {
            ConsoleHelper.PrintError("This CODE doesn't exist. Please insert an existing course CODE.");
            return; // Exit the function
        }

        // Find the student and the couse
        Student selectedStudent = students.First(s => s.Id == studentId);
        Course selectedCourse = courses.First(c => c.Code == courseCode);

        // Checks if the student is NOT enrolled
        if (!selectedCourse.IsStudentEnrolled(selectedStudent))
        {
            ConsoleHelper.PrintError($"Student {selectedStudent.Name} is not enrolled in {selectedCourse.Name}.");
            return; // Exit the function
        }

        // Disenroll the student
        selectedCourse.UnenrollStudent(selectedStudent);
        ConsoleHelper.PrintSuccess($"Student {selectedStudent.Name} has been unenrolled from {selectedCourse.Name}.");
        Console.Read();
    }
}
