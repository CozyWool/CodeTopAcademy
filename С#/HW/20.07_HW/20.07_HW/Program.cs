using _20._07_HW.CardGame;
using _20._07_HW.RaceGame;

while (true)
{
    Console.Write("Введите номер задания(1 - 2, 0 - выход из программы): ");
    string t = Console.ReadLine();
    Console.Clear();
    switch (t)
    {
        case "1":
            FirstTask();
            break;
        case "2":
            SecondTask();
            break;
        case "0":
            StopProgram();
            return;
        default:
            break;
    }
}

static void FirstTask()
{
    List<Car> cars = new()
    {
    new SportCar("Bugatti Chiron", 2),
    new PassengerCar("Hyundai Solaris", 4),
    new Bus("ЛиАЗ-5292",70),
    new Truck("MAN F90", 2)
    };
    RaceGame game = new(cars);
    game.StartRace();
    while (!game.IsRaceEnded)
    {
        game.Play();
        Console.WriteLine("Нажмите любую кнопку для следующего шага...");
        Console.ReadKey();
        Console.Clear();
    }
}
static void SecondTask()
{
    List<Player> players = new()
    {
        new Player("Alex"),
        new Player("John")
    };
    CardGame cardGame = new(players);
    cardGame.Start();
    cardGame.ShowPlayers();

    while (!cardGame.IsEnd)
    {
        cardGame.NextTurn();
        Console.WriteLine("\nНажмите любую кнопку для продолжения....");
        Console.ReadKey();
        Console.Clear();
    }
    Console.WriteLine("\tИгра окончена");
}
static void StopProgram()
{
    Console.Clear();
    Console.WriteLine("\n\t\tДо свидания!\n");
    Console.ReadKey();
}