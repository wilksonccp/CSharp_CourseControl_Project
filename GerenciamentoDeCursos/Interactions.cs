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
        """);
        Console.WriteLine();
    }
    public void AndPresentation()
    {
        Console.WriteLine("""
        Thank you for use the Course Manegemant Sistem
        ==============================================
        Press any key to exit
        """);
        Console.ReadLine();
    }
    public void ShowMainMenu()
    {
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
            Console.Clear();
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
            Console.Clear();
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
            Console.Clear();
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
            Console.Clear();
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
            Console.Clear();
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
        int studentId;
        do
        {
            Console.Write("Enter Student ID:");
            studentId = int.Parse(Console.ReadLine());

            if (ValidationHelper.StudentExist(studentId, students))
            {
                Console.WriteLine("This ID is already in use, please insert a new ID");
            }

        }
        while (ValidationHelper.StudentExist(studentId, students));
        
        int courseCode;
        do
        {
            Console.Write("Enter Course ID:");
            courseCode = int.Parse(Console.ReadLine());

            if (ValidationHelper.CourseExist(courseCode, courses))
            {
                Console.WriteLine("This ID is already in use, please insert a new ID");
            }

        }
        while (ValidationHelper.CourseExist(courseCode, courses));
          
        Student selectedStudent = students.FirstOrDefault(s => s.Id == studentId);
        Course selectedCourse = courses.FirstOrDefault(c => c.Code == courseCode);

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
