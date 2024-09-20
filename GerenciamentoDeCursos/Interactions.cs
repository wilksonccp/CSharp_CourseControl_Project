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
        Console.WriteLine("Welcome to the Courses Manegement Sistem");
        Console.WriteLine("===============================================");
        Console.WriteLine();
    }
    public void AndPresentation()
    {
        Console.WriteLine("Thank you for use the Course Manegemant Sistem");
        Console.WriteLine("===============================================");
        Console.WriteLine("Press any key to exit");
        Console.ReadLine();
    }
    public void ShowMainMenu()
    {
        Console.WriteLine($"    MAIN MENU\n---------------\n" +
        "1) Registrations\n" +
        "2) Enrollments\n" +
        "3) Exclusions\n" +
        "4) Reports\n" +
        "0) Exit");
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
        Console.Write("Enter Student ID:");
        int studentId = int.Parse(Console.ReadLine());
        Student selectedStudent = students.FirstOrDefault(s => s.Id == studentId);

        Console.Write("Enter course ID: ");
        int courseId = int.Parse(Console.ReadLine());
        Course selectedCourse = courses.FirstOrDefault(c => c.Code == courseId);

        if (selectedStudent != null && selectedCourse != null)
        {
            if (isEnrollment)
            {
                selectedCourse.EnrollStudent(selectedStudent);

            }
            else
            {
                selectedCourse.UnenrollStudent(selectedStudent);
            }
        }
        else
        {
            Console.WriteLine("Student or couse not found!");
        }
    }
}
