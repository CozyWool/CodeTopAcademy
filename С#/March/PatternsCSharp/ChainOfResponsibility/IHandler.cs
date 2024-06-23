using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace PatternsCSharp.ChainOfResponsibility
{
    public interface IHandler
    {
        string Name { get; set; }

        IHandler Next { get; set; }

        bool Handle(object request);
    }

    public class SquirrelHandler : IHandler
    {
        public string Name { get; set; } = "Squirrel";
        public IHandler Next { get; set; }

        public bool Handle(object request)
        {
            var value = request as string;
            if (value == "Nut")
            {
                Console.WriteLine($"{Name} eat {value}");
                return true;
            }

            return Next?.Handle(value) ?? false;
        }
    }
    public class MonkeyHandler : IHandler
    {
        public string Name { get; set; } = "Monkey";
        public IHandler Next { get; set; }

        public bool Handle(object request)
        {
            var value = request as string;
            if (value == "Banana")
            {
                Console.WriteLine($"{Name} eat {value}");
                return true;
            }

            return Next?.Handle(value) ?? false;
        }
    }
    public class DogHandler : IHandler
    {
        public string Name { get; set; } = "Dog";
        public IHandler Next { get; set; }

        public bool Handle(object request)
        {
            var value = request as string;
            if (value == "Bone")
            {
                Console.WriteLine($"{Name} eat {value}");
                return true;
            }

            return Next?.Handle(value) ?? false;
        }
    }
}
