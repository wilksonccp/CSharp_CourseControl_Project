using System;
using System.Globalization;
using System.Collections.Generic;

namespace GerenciamentoDeCursos
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List<Student> student = new List<Student>();
            Console.Write("Insita uma ID para o novo estudante: ");
            int studentId = int.Parse(Console.ReadLine());

            while (CheckIdExist(studentId, student))
            {
                Console.WriteLine("O número de Id inserido já existe, por gentileza insira uma nova ID: ");
                studentId = int.Parse(Console.ReadLine());
            }
            Console.Write("Nome do estudante: ");
            string name = Console.ReadLine();
            Console.Write("Email do estudante: ");
            string email = Console.ReadLine();
            student.Add(new Student(studentId, name, email));
            Console.WriteLine("Novo estudante adicionado com sucesso.");
        }
        private static bool CheckIdExist(int id, List<Student> students)
        {
            return students.Exists(student => student.Id == id);
        }
    }
}


