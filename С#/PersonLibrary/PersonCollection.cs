using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonLibrary
{
    internal class PersonCollection
    {
        private List<Person> persons = new();
        public void Add(Person person)
        {
             persons.Add(person);
        }
        public void Show()
        {
            foreach(Person person in persons)
            {
                person.Print();
            }
        }
    }
}
