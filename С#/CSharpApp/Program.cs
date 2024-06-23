using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CSharpApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //foreach (var value in args)
            //{
            //    Console.WriteLine(val);
            //}

            //int number = Convert.ToInt32(Console.ReadLine());
            //number = int.Parse(Console.ReadLine());
            //int.TryParse(Console.ReadLine(), out number);


            //OneDimensionArray();
            //TwoDimensionArray();
            //JaggedArray();
            //StringExample();
            //StringFormatExample();
            //StringBuilderExample();
            //EnumExample();
            //ReadFileExample();

            //Point point = new Point(4, 5);
            //Console.WriteLine($"{point.x}, {point.y}");
            //StructExample(point);
            //Console.WriteLine($"{point.x}, {point.y}");

            //ClassExample();

            //int value = 5;
            //Student student = new Student("Vladislav", "Sergeev", 16);
            //Student student2 = student;
            //double d;
            //RefOutExample(ref value, ref student, out d);
            //Console.WriteLine($"After func student: {student}");
            //Console.WriteLine($"After func student2: {student2}");
            //Console.WriteLine($"After func d: {d}");

            //SumExample(new int[] { 4, 6, 12, 34 });
            //SumExample(4, 6, 12, 34);

            Console.ReadLine();
        }

        private static void SumExample(params int[] array)
        {
            int sum = 0;
            for (int i = 0; i < array.Length; i++)
            {
                sum += array[i];
            }
            Console.WriteLine($"Сумма чисел: {sum}");
        }

        private static void RefOutExample(ref int i, ref Student student, out double value)
        {
            // ref out

            //Console.WriteLine($"Before: {i}");
            //i += 45;
            //Console.WriteLine($"After: {i}");

            Console.WriteLine($"Before: {student}");
            student = new Student("Petr", "Petrov", 30);
            Console.WriteLine($"After: {student}");
            value = Math.PI;
        }

        private static void ClassExample()
        {
            Student student = new Student("Vladislav","Sergeev",16);
            //student.Print();
            Console.WriteLine(student);
        }

        private static void StructExample(Point point)
        {
            point.x = 1;
            point.y = 2;
            Console.WriteLine($"{point.x}, {point.y}");
        }

        private static void ReadFileExample()
        {
            var sr = new StreamReader("input.txt");
            
            while (!sr.EndOfStream)
            {
                var line = sr.ReadLine();
                Console.WriteLine(line);
            }
        }

        private static void EnumExample()
        {
            var wednesday = DayOfWeek.Wednesday;
            Console.WriteLine(Enum.GetName(typeof(DayOfWeek), wednesday));

            Console.WriteLine();

            foreach (var name in Enum.GetNames(typeof(DayOfWeek)))
            {
                Console.WriteLine(name);
            }

            Console.WriteLine();

            foreach (int value in Enum.GetValues(typeof(DayOfWeek)))
            {
                Console.WriteLine(value);
            }

            var val = "Saturday";
            DayOfWeek d = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), val);
            Console.WriteLine(d);

            Console.WriteLine();

            Console.WriteLine(Enum.IsDefined(typeof(DayOfWeek), val));
            Console.WriteLine(Enum.IsDefined(typeof(DayOfWeek), 55));
        }

        private static void StringExample()
        {
            // char, char[], string, Encoding
            string str = "Это текст с русскими символами";
            string str2 = @"\ \n \b \t \0 Это текст с русскими символами";
            char[] chars = { 'П','р','о','с','т','о'};
            str = new string(chars);
            Console.WriteLine(str);
        }
        private static void StringFormatExample()
        {
            var date = DateTime.Now;
            var str = "Просто строка";
            string.Format("Текущая дата: {0}, {1}", date, str);

            var pi = Math.PI;
            var number = 10;
            Console.WriteLine($"Текущая дата: {date:d MMMM yyyy}, {pi:0.00}");
            Console.WriteLine($"{number}");
        }
        private static void StringBuilderExample()
        {
            // строка неизменяема
            string str = "Привет мир!";
            // char[] chars <-> StringBuilder
            StringBuilder sb = new StringBuilder("привет мир!");
            sb.Append("!!!");
            sb[0] = char.ToUpper(sb[0]);
            Console.WriteLine(sb);

        }
        private static void OneDimensionArray()
        {
            int[] array = new int[10];
            InitializeRandom(array);
            Array.Sort(array);
            
            Print(array);
            Console.WriteLine($"Максимальное значение: {array.Max()}, минимальное значение: {array.Min()}");
        }
        static int MinValue(int[] array)
        {
            int min = array[0];
            for (int i = 1; i < array.Length; i++)
                min = array[i] < min ? array[i] : min;
            return min;
        }
        static int MaxValue(int[] array)
        {
            int max = array[0];
            for (int i = 1; i < array.Length; i++)
                max = array[i] > max ? array[i] : max;
            return max;
        }
        static void InitializeRandom(int[] array)
        {
            Random random = new Random();

            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(1, 50);
            }
        }

        static void Print(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{array[i]} ");
            }
            Console.WriteLine();
        }
        private static void TwoDimensionArray()
        {
            int[,] array = new int[3, 4];

            InitializeRandom(array);
            Print(array);
            Console.WriteLine($"Максимальное значение: {MaxValue(array)}, минимальное значение: {MinValue(array)}");
        }
        static int MinValue(int[,] array)
        {
            int min = array[0, 0];
            foreach (var value in array)
                if (value < min) min = value;
            return min;
        }
        static int MaxValue(int[,] array)
        {
            int max = array[0, 0];
            foreach (var value in array)
                if (value > max) max = value;
            return max;
        }
        static void InitializeRandom(int[,] array)
        {
            Random random = new Random();

            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int column = 0; column < array.GetLength(1); column++)
                {
                    array[row, column] = random.Next(1, 50);
                }
            }
        }
        static void Print(int[,] array)
        {
            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int column = 0; column < array.GetLength(0); column++)
                {
                    Console.Write($"{array[row, column]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }

        private static void JaggedArray()
        {
            int[][] array = new int[3][];
            array[0] = new int[3];
            array[1] = new int[4];
            array[2] = new int[1];
            InitializeRandom(array);
            Print(array);
            Console.WriteLine($"Максимальное значение: {MaxValue(array)}, минимальное значение: {MinValue(array)}");
        }
        static int MinValue(int[][] array)
        {
            int min = array[0][0];
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++)
                    if (array[i][j] < min) min = array[i][j];

            return min;
        }
        static int MaxValue(int[][] array)
        {
            int max = array[0][0];
            for (int i = 0; i < array.Length; i++)
                for (int j = 0; j < array[i].Length; j++)
                    if (array[i][j] > max) max = array[i][j];

            return max;
        }
        static void InitializeRandom(int[][] array)
        {
            Random random = new Random();

            for (int row = 0; row < array.GetLength(0); row++)
            {
                for (int column = 0; column < array[row].GetLength(0); column++)
                {
                    array[row][column] = random.Next(1, 50);
                }
            }
        }
        static void Print(int[][] array)
        {
            for (int row = 0; row < array.Length; row++)
            {
                for (int column = 0; column < array[row].Length; column++)
                {
                    Console.Write($"{array[row][column]} ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
