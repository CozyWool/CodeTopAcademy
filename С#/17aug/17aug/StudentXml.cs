using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace _17aug
{
    public static class StudentXml
    {
        public static XDocument doc;
        public static XElement CreateStudent(string name, int age, string groupName)
        {
            var student = new XElement("Student");
            student.Add(new XAttribute("Name", name));
            student.Add(new XElement("Age", age));
            student.Add(new XElement("GroupName", groupName));
            return student;
        }
        public static void AddStudent(this XDocument doc, string name, int age, string groupName)
        {
            var students = doc.Element("Students");
            students.Add(CreateStudent(name, age, groupName));
        }
        public static void SearchStudentsGreaterThanAge(XDocument doc, int age)
        {
            var students = doc.Descendants("Student").Where(x => int.Parse(x.Element("Age").Value) > age);
            Console.WriteLine($"\tСтуденты, старше {age}");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Attribute("Name").Value}, " +
                    $"{student.Element("Age").Value}, " +
                    $"{student.Element("GroupName").Value}");
            }
        }
        public static void PrintStudents(XDocument doc)
        {
            var students = doc.Descendants("Student");
            Console.WriteLine($"\tСтуденты");
            foreach (var student in students)
            {
                Console.WriteLine($"{student.Attribute("Name").Value}, " +
                    $"{student.Element("Age").Value}, " +
                    $"{student.Element("GroupName").Value}");
            }
        }
        public static XDocument GenerateXmlLinq()
        {
            var students = new XElement("Students");
            students.Add(CreateStudent("Alex", 20, "П12"));
            students.Add(CreateStudent("John", 19, "БВ112"));
            students.Add(CreateStudent("Bob", 18, "БВ111"));


            doc = new XDocument();
            doc.Add(students);
            doc.AddStudent("Robert", 25, "П11");
            doc.Save("LinqStudents.xml");
            return doc;
        }
    }
}
