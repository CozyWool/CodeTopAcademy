using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11mar.School
{
    public class Student
    {
        private int id;
        private string name;
        private int age;
        private DateTime dateBirth;
        private string groupName;

        //public int Id { get { return id; } set { id = value; } }
        //public string Name { get { return name; } set { name = value; } }

        public int Id { get { return id; } }
        public string Name { get => name; }
        public int Age
        {
            get { return age; }
            set
            {
                if (age < 0)
                {
                    Console.WriteLine($"Возраст не может быть меньше нуля: {age}");
                    return;
                }
                age = value;
            }
        }
        public string GroupName { get => groupName; set => groupName = value; }
        public DateTime DateBirth { get => dateBirth; set => dateBirth = value; }

        public Student(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        //public int GetAge() { return age; }
        //public void SetAge(int age) { this.age = age; }
        //public int GetAge() => age;
        //public void SetAge(int age) => this.age = age;
    }
}
