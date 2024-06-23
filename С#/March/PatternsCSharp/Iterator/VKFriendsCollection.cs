using PatternsCSharp.Decorator;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PatternsCSharp.Iterator
{
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
    }

    public class VKFriendsCollection : IEnumerable<Person>
    {   
        private List<Person> _friends = new();

        public IEnumerator<Person> GetEnumerator()
        {
            return new PersonEnumerator(_friends);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new PersonEnumerator(_friends);
        }

        public void AddFriend(Person person)
        {
            _friends.Add(person);
        }
    }
    public class PersonEnumerator : IEnumerator<Person>
    {
        private int _position = -1;
        private readonly List<Person> persons;

        public PersonEnumerator(List<Person> persons)
        {
            this.persons = persons;
        }

        public Person Current => persons[_position];
        //public Person Current
        //{
        //    get
        //    {
        //        if(_position == -1) _position = 0;
        //        else if(_position >= persons.Count) _position = persons.Count - 1;
        //        return persons[_position];
        //    }
        //}

        object IEnumerator.Current => Current;

        public void Dispose() => throw new NotImplementedException();

        public bool MoveNext() => _position < persons.Count;

        public void Reset() => _position = -1;
    }
}
