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
        PRESS ANY KEY TO CONTINUE
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
                    registrerList(students, Student.RegistrerStudent);
                    break;
                case "2":
                    registrerList(courses, Course.RegisterCourse);
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
                    HandleEnrollment(students, courses, true);
                    break;
                case "2":
                    // unenroll student
                    HandleEnrollment(students, courses, false);
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
                case "1":
                    // TODO: builder this method
                    temporaryStudent.DeleteStudent();
                    break;
                case "2":
                    // TODO: builder this method
                    temporaryCouse.DeleteCourse();
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
    internal void registrerList<T>(List<T> list, Action<List<T>> registrerAction)
    {
        registrerAction(list);
    }
    public void HandleEnrollment(List<Student> students, List<Course> courses, bool isEnrollment)
    {
        // Request and validate the student ID
        int studentId = 0;
        do
        {
            Console.Write("Enter Student ID: ");
            string studentInput = Console.ReadLine();
            if (!ValidationHelper.IsValidString(studentInput) || !ValidationHelper.IsNumeric(studentInput))
            {
                Console.WriteLine("Error: The Student ID must be a valid number.");
                continue;
            }

            studentId = int.Parse(studentInput);

            if (!ValidationHelper.StudentExist(studentId, students))
            {
                Console.WriteLine("This ID doesn't exist, please insert an existing student ID.");
            }
        } while (!ValidationHelper.StudentExist(studentId, students));

        // Request and validate the course code
        int courseCode = 0;
        do
        {
            Console.Write("Enter Course ID: ");
            string courseInput = Console.ReadLine();
            if (!ValidationHelper.IsValidString(courseInput) || !ValidationHelper.IsNumeric(courseInput))
            {
                Console.WriteLine("Error: The Course ID must be a valid number.");
                continue;
            }

            courseCode = int.Parse(courseInput);

            if (!ValidationHelper.CourseExist(courseCode, courses))
            {
                Console.WriteLine("This CODE doesn't exist, please insert an existing course CODE.");
            }
        } while (!ValidationHelper.CourseExist(courseCode, courses));

        // Find the student and course
        Student selectedStudent = students.FirstOrDefault(s => s.Id == studentId);
        Course selectedCourse = courses.FirstOrDefault(c => c.Code == courseCode);

        // TODO: CRIAR UMA MENSAGEM PERSONALIZADA PARA CADA MATRICULA
        // Perform enrollment or unenrollment
        if (isEnrollment)
        {
            selectedCourse.EnrollStudent(selectedStudent);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Student enrolled successfully");
            Console.ResetColor();
            Console.Read();
        }
        else
        {
            selectedCourse.UnenrollStudent(selectedStudent);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("Student unenrolled successfully");
            Console.ResetColor();
            Console.Read();
        }

    }
}
