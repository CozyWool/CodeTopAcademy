namespace _20._07_HW.RaceGame
{
    public delegate void FinishHandler(Car car);
    public delegate void StartHandler();
    public class RaceGame
    {
        public List<Car> Cars = new();


        public event StartHandler OnStart;
        public event FinishHandler OnFinish;
        public bool IsRaceEnded { get; private set; }
        public RaceGame(List<Car> cars)
        {
            Cars = cars;
            foreach (Car car in Cars)
            {
                OnStart += car.Start;
                OnFinish += car.Finish;
            }
        }
        public void PrintCars()
        {
            Console.WriteLine("\tСписок машин");
            foreach (Car car in Cars)
            {
                Console.WriteLine($"{car}\n");
            }
        }
        public void Play() // true = игра окончена, false = все еще идёт
        {
            foreach (Car car in Cars)
            {
                car.Drive();
                if (car.Distance >= 300)
                {
                    FinishRace(car);
                    IsRaceEnded = true;
                    return;
                }
            }
            PrintCars();
        }

        private void FinishRace(Car car)
        {
            PrintCars();
            Console.WriteLine("\t\tФиниш!\n");
            OnFinish?.Invoke(car);
        }
        public void StartRace()
        {
            Console.WriteLine("\tГонка начинается!\n");
            OnStart?.Invoke();
        }
    }
}
