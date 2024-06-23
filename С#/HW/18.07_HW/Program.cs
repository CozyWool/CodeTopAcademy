using _18._07_HW;
using _18._07_HW.Workers;

internal class Program
{
    private static void Main(string[] args)
    {
        House house = new House();
        List<Worker> workers = new List<Worker>()
        {
            new Worker("John", "Строитель", house),
            new Worker("Alex", "Строитель", house),
            new Worker("Bob", "Строитель", house)
        };
        TeamLeader leader = new TeamLeader("Andrew", "Бригадир", house);
        Team team = new Team(workers, leader, house);

        Console.WriteLine("\n------------------------\n");

        Console.WriteLine("\tБригада строителей");
        Console.WriteLine(team);

        Console.WriteLine("\n------------------------\n");
        Console.Write("Для продолжения нажмите любую клавишу...");
        Console.ReadKey();
        Console.Clear();

        while(!team.House.IsHouseReady())
        {
            Console.WriteLine("\n------------------------\n");

            team.Work();

            Console.WriteLine("\n------------------------\n");
            Console.Write("Для продолжения нажмите любую клавишу...");
            Console.ReadKey();
            Console.Clear();
        }

        Console.WriteLine("\tДом построен!!!\n");
        Console.WriteLine("   *");
        Console.WriteLine("  ***");
        Console.WriteLine(" *****");
        Console.WriteLine("*******");
        Console.WriteLine("|     |");
        Console.WriteLine("|+|  _|");
        Console.WriteLine("|   |*| ");
        Console.WriteLine("|___|_| ");
    }
}