using _18._07_HW.Interfaces;
using _18._07_HW.Parts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18._07_HW.Workers
{
    public class Worker : IWorker
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public House House { get; set; } // Каким домом занимается

        public Worker() : this("", "", null) { }
        public Worker(string name, string position, House house)
        {
            Name = name;
            Position = position;
            House = house;
        }

        public void Work()
        {
            IPart? part = null;
            switch (House.WhatToDo())
            {
                case Enums.PartTypes.None:
                    break;
                case Enums.PartTypes.Basement:
                    part = House.Basement;
                    break;
                case Enums.PartTypes.Wall:
                    foreach (Wall wall in House.Walls)
                    {
                        if (!wall.IsBuilded)
                            part = wall;
                    }
                    break;
                case Enums.PartTypes.Window:
                    foreach (Window window in House.Windows)
                    {
                        if (!window.IsBuilded)
                            part = window;
                    }
                    break;
                case Enums.PartTypes.Door:
                    part = House.Door;
                    break;
                case Enums.PartTypes.Roof:
                    part = House.Roof;
                    break;
                default:
                    break;
            }
            if (part == null)
            {
                Console.WriteLine($"{Name} не работает, т.к нечего строить");
                return;
            }
            Console.WriteLine($"{Name} взялся за {part.Type}");
            part.ResponseWorker = this;
            House.Build(part);
        }

        public override string ToString()
        {
            return ($"{Name}: {Position}");
        }
    }
}
