using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PatternsCSharp.Observer
{
    internal class Subscriber
    {
        private readonly string name;

        public Subscriber(string name)
        {
            this.name = name;
        }

        public void NotifyMe(string message)
        {
            Console.WriteLine($"Подписчик {name}. {message}");
        }
    }
}
