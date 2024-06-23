using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    public class Employee : Person
    {
        public Employee(string firstName, string lastName, int age) : base(firstName, lastName, age)
        {
        }
    }
}
