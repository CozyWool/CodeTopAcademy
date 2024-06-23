namespace _20._07_HW.RaceGame
{
    public class Bus : Car
    {
        public Bus() : base(0, 20, 50, "None", 40) { }
        public Bus(string model, int capacity)
        {
            MinSpeed = 20;
            MaxSpeed = 50;
            Distance = 0;
            Model = model;
            Capacity = capacity;
        }
    }
}
