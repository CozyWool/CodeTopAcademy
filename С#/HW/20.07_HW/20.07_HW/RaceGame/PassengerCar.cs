namespace _20._07_HW.RaceGame
{
    public class PassengerCar : Car
    {

        public PassengerCar() : this("None", 4) { }
        public PassengerCar(string model, int capacity)
        {
            MinSpeed = 30;
            MaxSpeed = 70;
            Distance = 0;
            Model = model;
            Capacity = capacity;
        }
    }
}
