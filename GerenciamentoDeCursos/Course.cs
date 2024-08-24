using System.Data.Common;

namespace GerenciamentoDeCursos;

public class Course
{
    public int Id { get; private set; }
    public string Name { get; set; }
    public List<Student> Students { get; } = new List<Student>();

    public Course (string name, int id)
    {
        Id = id;
        Name = name;
    }

    internal void addStudent(Student student)
    {
        Students.Add(student);
    }
    internal void remStudent(int studentId)
    {
        Students.RemoveAll(s => s.Id == studentId);
    }
}
