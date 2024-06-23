using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Schooler = _11mar.School.Student;
using Stud = _11mar.Institute.Student;
using ItTop = _11mar.ItTopAcademy.Student;

namespace _11mar
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //PropertyExample();
            //NamespacesExample();
            InheritanceExample();

            Console.ReadLine();
        }

        private static void InheritanceExample()
        {
            var printer = new Printer();
            printer.Print();
            printer.Print("Привет, Мир!");
            Console.WriteLine($"Тип принтера: {printer.GetPrinterType()}");

            Human programmer = new Programmer("Alex", "P", "backend");
            programmer.Print();
            Console.WriteLine(((Programmer)programmer).GetPostion());
        }

        private static void NamespacesExample()
        {
            //School.Student
            Schooler schoolStudent = new Schooler(1, "Alex");
            //Institute.Student
            Stud instituteStudent = new Stud { Course = 3 };
            //ItTopAcademy.Student
            ItTop itTopAcademyStudent = new ItTop { CurrentSubject = "C#" };
            Console.WriteLine(schoolStudent.Name);
            Console.WriteLine(instituteStudent.Course);
            Console.WriteLine(itTopAcademyStudent.CurrentSubject);
        }

        //private static void PropertyExample()
        //{
        //    //Student student = new Student(1, "Alex");
        //    //student.Age = 32;
        //    //Console.WriteLine(student.Age);
        //    Student student = null;
        //    DateTime? date = null;
        //    date = student?.DateBirth ?? DateTime.Now;

        //    Console.WriteLine(date);
        //}
    }
}
