using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class Person
    {
        private readonly string firstName;
        private readonly string lastName;
        private readonly int age;

        public Person(string firstName, string lastName, int age)
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.age = age;
        }

        public void Print()
        {
            Console.WriteLine($"{firstName} {lastName}, {age}");
        }
    }
}
