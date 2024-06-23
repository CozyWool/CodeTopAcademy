using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace _20._07_HW.RaceGame
{

    public abstract class Car
    {
        private int _currentSpeed;
        public int Distance;

        public int MinSpeed { get; set; }
        public int MaxSpeed { get; set; }
        public int CurrentSpeed
        {
            get => _currentSpeed;
            set
            {
                if (value >= MinSpeed && value <= MaxSpeed)
                    _currentSpeed = value;
            }
        }
        public string Model { get; set; }
        public int Capacity { get; set; }
        public void Start()
        {
            Drive();
            Console.WriteLine($"{Model}: Машина стартовала со скоростью {CurrentSpeed}!");
        }
        public void Finish(Car car)
        {
            CurrentSpeed = 0;
            Console.WriteLine($"{Model}: Машина {car.Model} финишировала и победила!");
        }

        protected Car(int distance, int minSpeed, int maxSpeed, string model, int capacity)
        {
            Distance = distance;
            MinSpeed = minSpeed;
            MaxSpeed = maxSpeed;
            CurrentSpeed = new Random().Next(MinSpeed, MaxSpeed);
            Model = model;
            Capacity = capacity;
        }
        protected Car() : this(0, 0, 0, "", 0) { }

        public void Drive()
        {
            CurrentSpeed = new Random().Next(MinSpeed, MaxSpeed);
            Distance += CurrentSpeed;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.Append($"Модель автомобиля: {Model}\n");
            sb.Append($"Вместимость: {Capacity}\n");
            sb.Append($"Текущая скорость | Пройденное расстояние | Максимальная скорость | Минимальная скорость \n{CurrentSpeed} \t\t | {Distance} \t\t\t | {MaxSpeed} \t\t\t | {MinSpeed}\n");

            return sb.ToString();
        }
    }
}
