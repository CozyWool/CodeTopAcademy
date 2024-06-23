using _18._07_HW.Interfaces;

namespace _18._07_HW.Workers
{
    public class TeamLeader : IWorker
    {
        public string Name { get; set; }
        public string Position { get; set; }
        public House House { get; set; } // Каким домом занимается

        public TeamLeader() : this("", "", null) { }
        public TeamLeader(string name, string position, House house)
        {
            Name = name;
            Position = position;
            House = house;
        }

        public void Work()
        {
            Console.WriteLine($"\n\tОтчёт бригадира {Name}");
            Console.WriteLine($"  Фундамент");
            Console.WriteLine($"{House.Basement}");
            Console.WriteLine($"\tСтены");
            foreach (var wall in House.Walls)
            {
                Console.WriteLine($"{wall}");
            }
            Console.WriteLine($"  Дверь");
            Console.WriteLine($"{House.Door}");
            Console.WriteLine($"  Окна");
            foreach (var window in House.Windows)
            {
                Console.WriteLine($"{window}");
            }
            Console.WriteLine($"  Крыша");
            Console.WriteLine($"{House.Roof}");
        }

        public override string ToString()
        {
            return ($"{Name}: {Position}");
        }
    }
}
