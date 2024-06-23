using _04._05_HW;

internal class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Введите номер задания(1 - 7, 0 - выход из программы): ");
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
                case "3":
                    ThirdTask();
                    break;
                case "4":
                    FourthTask();
                    break;
                case "0":
                    StopProgram();
                    return;
                default:
                    break;
            }
        }
    }

    private static void FirstTask()
    {
        Console.Write("Введите длину строны квадрата: ");
        int len = Convert.ToInt32(Console.ReadLine());
        Console.Write("Введите символ, из которого будет изображён квадрат: ");
        char symbol = Convert.ToChar(Console.ReadLine());
        DrawSquare(len, symbol);
    }
    private static void DrawSquare(int len, char symbol)
    {
        for (int i = 0; i < len; i++)
        {
            Console.WriteLine(string.Concat(Enumerable.Repeat(symbol, len)));
        }
    }
    private static void SecondTask()
    {
        Console.Write("Введите число: ");
        int num = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine($"{num}{(IsPalindrome(num) ? "" :" не")} палиндром");
    }

    private static bool IsPalindrome(int num)
    {
        return num.ToString() == new string(num.ToString().Reverse().ToArray());
    }

    private static void ThirdTask()
    {
        Console.Write("Введите оригинальный массив:");
        int[] orignal = Console.ReadLine().Split().Select(int.Parse).ToArray();
        Console.Write("Введите массив для фильтрации:");
        int[] filter = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] result = FilterArray(orignal, filter);
        Console.Write($"Результат фильтрации: ");
        foreach (int i in result)
            Console.Write(i + " ");
        Console.WriteLine();
    }
    private static int[] FilterArray(int[] orignal, int[] filter)
    {
        List<int> result = new();
        foreach (int i in orignal) 
        {
            if(!filter.Contains(i))
                result.Add(i);
        }
        return result.ToArray();
    }
    private static void FourthTask()
    {
        Website website = new();
        website.Input();
        Console.WriteLine();
        website.Output();
        Console.WriteLine("\tСмена ip-адреса на 111.111.111.111");
        website.        Address = "111.111.111.111";
        website.Output();
        Console.WriteLine($"Имя сайта: {website.Name}");
    }

    static void StopProgram()
    {
        Console.Clear();
        Console.WriteLine("\n\t\tДо свидания!\n");
        Console.ReadKey();
    }
}
