using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace _08aug
{
    public class Person : ISerializable
    {
        [NonSerialized, JsonIgnore]
        private int id;
        private string name;
        private int age;

        public Person(int id, string name, int age)
        {
            Id = id;
            Name = name;
            Age = age;
        }

        public Person() : this(0, "", 0) { }


        [XmlIgnore, JsonIgnore] public int Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public int Age { get => age; set => age = value; }

        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("Namee", Name);
            info.AddValue("Age", Age);
        }

        public override string ToString() => $"Имя: {Name} Возраст: {Age} Id: {Id}";
    }
}
