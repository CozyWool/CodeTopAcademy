namespace _20._07_HW.RaceGame
{
    public class Truck : Car
    {
        public Truck() : base(0, 30, 80, "None", 2) { }
        public Truck(string model, int capacity)
        {
            MinSpeed = 30;
            MaxSpeed = 80;
            Distance = 0;
            Model = model;
            Capacity = capacity;
        }
    }
}
