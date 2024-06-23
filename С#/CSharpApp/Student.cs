using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpApp
{
    public class Student
    {
        // static, const, readonly
        //public const double PI = 3.14;
        private readonly string _firstName;
        private string _lastName;
        private int _age;

        static Student()
        {
            // иннциализация статических полей
        }

        public Student(string firstName, string lastName) : this(firstName, lastName, 0) { }
        public Student(string firstName, string lastName, int age)
        {
            _firstName = firstName;
            _lastName = lastName;
            _age = age;
        }

        public void UpdateAge()
        {
            _age++;
        }
        public void UpdateAge(int incrementValue)
        {
            _age+= incrementValue;
        }

        public override string ToString() 
        {
            return $"{_firstName} {_lastName}, {_age}";
        }
    }
}
