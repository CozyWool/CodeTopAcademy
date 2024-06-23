using PatternsCSharp.Iterator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsCSharp.Prototype
{   
    public class Person : ICloneable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public Person() { }
      
        public object Clone()
        {
            var newPerson = ShallowCopy();
            newPerson.Address = Address != null ? Address.Clone() as Address : null;
            return newPerson;
        }
        private Person ShallowCopy()
        {
            return MemberwiseClone() as Person;
        }
    }
}
