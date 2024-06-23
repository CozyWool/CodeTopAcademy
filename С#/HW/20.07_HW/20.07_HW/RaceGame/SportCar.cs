namespace _20._07_HW.RaceGame
{
    public class SportCar : Car
    {

        public SportCar() : base(0, 50, 120, "None", 2) { }

        public SportCar(string model, int capacity)
        {
            MinSpeed = 50;
            MaxSpeed = 120;
            Distance = 0;
            Model = model;
            Capacity = capacity;
        }
    }
}
