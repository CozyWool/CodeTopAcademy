using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _25._04_HW
{
    internal class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Write("Введите номер задания(1 - 7, 0 - выход из программы): ");
                int t = int.Parse(Console.ReadLine());
                Console.Clear();
                switch (t)
                {
                    case 1:
                        Console.Write("Введите число от 1 до 100: ");
                        int x = int.Parse(Console.ReadLine());
                        if (x < 1 || x > 100)
                        {
                            Console.WriteLine("Ошибка! Вы ввели число не от 1 до 100.");
                            break;
                        }

                        Console.Write(x % 3 == 0 ? "Fizz" + (x % 5 == 0 ? " " : "\n") : null);
                        Console.Write(x % 5 == 0 ? "Buzz\n" : null);
                        Console.Write(x % 5 != 0 && x % 3 != 0 ? $"{x}\n" : null);
                        break;
                    case 2:
                        Console.Write("Введите значение: ");
                        double value = double.Parse(Console.ReadLine());
                        Console.Write("Введите процент: ");
                        double percent = double.Parse(Console.ReadLine());

                        Console.WriteLine(value / 100 * percent);
                        break;
                    case 3:
                        Console.Write("Введите четыре цифры через пробел: ");
                        string[] digits = Console.ReadLine().Split();
                        if (digits[0] == "0") Array.Reverse(digits); // число не может начинаться на ноль
                        foreach (string digit in digits)
                            Console.Write(digit);
                        Console.WriteLine();
                        break;
                    case 4:
                        Console.Write("Введите шестизначное число: ");
                        string str = Console.ReadLine();
                        int number;
                        if(!int.TryParse(str,out number) && str.Length != 6)
                        {
                            Console.WriteLine("Ошибка! Вы ввели не шестизначное число.");
                            break;
                        }
                        Console.Write("Введите разряды, которые нужно поменять местами, через пробел: ");

                        int[] _digits = Console.ReadLine().Split().Select(int.Parse).ToArray(); // cyberforum, хотел красивый ввод через пробел)
                        int digit1 = _digits[0] - 1;
                        int digit2 = _digits[1] - 1;

                        StringBuilder sb = new StringBuilder(str);
                        (sb[digit1], sb[digit2]) = (sb[digit2], sb[digit1]);
                        Console.WriteLine(sb.ToString());
                        break;
                    case 5:
                        Console.Write("Введите дату(dd.mm.yy): ");
                        DateTime dateTime = DateTime.Parse(Console.ReadLine());
                        var season = DefineSeason(dateTime.Month);
                        Console.WriteLine($"{season} {dateTime.DayOfWeek}");
                        break;
                    case 6:
                        Console.Write("Введите температуру(°C или °F): ");
                        int temparture = int.Parse(Console.ReadLine());
                        Console.Write("C - в °C"
                                      + "\nF - в °F"
                                      + "\nВведите в какие единицы измерения нужно перевести температуру: ");
                        string choice = Console.ReadLine();
                        Console.WriteLine(choice == "F" 
                            ? temparture * 1.8 + 32 
                            : (choice == "C" ? (temparture - 32) / 1.8 : temparture));
                        break;
                    case 7:
                        Console.Write("Введите два числа через пробел: ");
                        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray(); // cyberforum, хотел красивый ввод через пробел)
                        int a = input[0];
                        int b = input[1];
                        if (a > b) (a, b) = (b, a);

                        if (a % 2 != 0)
                            a++;
                        for (int i = a; i <= b; i += 2)
                            Console.Write(i + " ");
                        Console.WriteLine();
                        break;
                    case 0:
                        Console.Clear();
                        Console.WriteLine("\n\t\tДо свидания!\n");
                        Console.ReadKey();
                        return;
                    default:
                        break;
                }
            }
        }

        private static string DefineSeason(int month)
        {
            switch (month) 
            {
                case 1:
                    return "Winter";
                case 2:
                    return "Winter";
                case 3:
                    return "Spring";
                case 4:
                    return "Spring";
                case 5:
                    return "Spring";
                case 6:
                    return "Summer";
                case 7:
                    return "Summer";
                case 8:
                    return "Summer";
                case 9:
                    return "Autumn";
                case 10:
                    return "Autumn";
                case 11:
                    return "Autumn";
                case 12:
                    return "Winter";
                default:
                    return "";
            }
        }
    }
}
