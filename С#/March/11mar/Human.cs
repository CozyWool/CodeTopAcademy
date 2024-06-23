using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11mar
{
    public class Human
    {
        protected string _firstName;
        protected string _lastName;
        protected DateTime _birthDate;

        //public Human() : this("John", "Doe", DateTime.MinValue) { }
        public Human(string firstName, string lastName) : this(firstName, lastName, DateTime.MinValue) { }
        public Human(string firstName, string lastName, DateTime birthDate)
        {
            _firstName = firstName;
            _lastName = lastName;
            _birthDate = birthDate;
        }

        public virtual void Print() => Console.WriteLine($"{_firstName}, {_lastName}, {_birthDate}");
    }

    public class Programmer : Human
    {
        private string _position;

        public Programmer(string firstName, string lastName, string position) : base(firstName, lastName)
        {
            _position = position;
        }

        public override void Print()
        {
            base.Print();
            Console.WriteLine($"{_position}");
        }

        public string GetPostion() => _position;
    }
}
