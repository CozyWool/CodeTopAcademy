using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31aug.FirstTask
{
    public class Person : IPropertyChanged
    {
        public event PropertyEventHandler PropertyChanged;

        private string _name;
        private int _age;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new(nameof(Name)));
            }
        }

        public int Age
        {
            get => _age;
            set
            {
                _age = value;
                PropertyChanged?.Invoke(this, new(nameof(Age)));
            }
        }

        public Person(string name, int age)
        {
            Name = name;
            Age = age;
            PropertyChanged += OnPropertyChanged;
        }

        private void OnPropertyChanged(object sender, PropertyEventArgs e)
        {
            if (sender is Person p)
            {
                Console.WriteLine($"{p.Name}: изменилось свойство {e.PropertyName}");
            }
        }

        public Person() : this("", 0) { }
    }
}
