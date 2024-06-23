using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace _20._07_HW.CardGame
{
    public class Player
    {
        public List<Card> Hand { get; set; }
        public string Name { get; set; }

        public Player(List<Card> hand, string name)
        {
            Hand = hand;
            Name = name;
        }

        public Player(string name) : this(new List<Card>(), name) { }


        public Card? AskCard()
        {
            if (Hand.Count == 0) return null;

            Console.WriteLine($"\n\t{Name} выбирает карту");
            for (int i = 0; i < Hand.Count; i++)
            {
                Console.WriteLine($"{i + 1}:{Hand[i]}");
            }
            Console.Write($"{Name} выберите карту:");
            int index;
            try
            {
                index = int.Parse(Console.ReadLine()) - 1;

                while (index < 0 || index >= Hand.Count)
                {
                    Console.WriteLine("\tПожалуйста, введите корректный номер карты");
                    Console.Write($"{Name} выберите карту:");
                    index = int.Parse(Console.ReadLine()) - 1;
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Ошибка! Неправильный формат данных, выбирается 1 карта по умолчанию");
                index = 0;
            }
            return Hand[index];
        }

        public override string ToString()
        {
            StringBuilder sb = new($"{Name}: ");
            foreach (var card in Hand)
            {
                sb.Append($" {card} ");
            }
            return sb.ToString();
        }
    }
}
