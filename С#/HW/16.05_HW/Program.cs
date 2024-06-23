using _16._05_HW;

public class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Введите номер задания(1 - 2, 0 - выход из программы): ");
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
        Journal j1 = new Journal("Мурзилка",
                           "murzilka@gmail.com",
                           "Совесткий журнал со сказками",
                           "+7800553535",
                           30);
        Journal j2 = new Journal("Газета",
                           "test@gmail.com",
                           "Новостная газета",
                           "+79826534244",
                           100);
        Console.WriteLine($"\tПервый журнал\n{j1}");
        Console.WriteLine($"\tВторой журнал\n{j2}");

        Console.WriteLine($"j1 + 20: {(j1 + 10).WorkersCount}");
        Console.WriteLine($"j2 - 50: {(j2 - 50).WorkersCount}");
        Console.WriteLine($"j1 > j2: {j1 > j2}");
        Console.WriteLine($"j1 < j2: {j1 < j2}");
        Console.WriteLine($"j1 == j2: {j1 == j2}");
        Console.WriteLine($"j1 != j2: {j1 != j2}");
        Console.WriteLine($"j1.Equals(j2): {j1.Equals(j2)}");
    }
    private static void SecondTask()
    {
        Shop s1 = new Shop("Магнит",
                           "test@gmail.com",
                           "Продуктовый магазин",
                           "ул. Александра Пушкина 23",
                           "+7800553535",
                           30);
        Shop s2 = new Shop("Строительный двор",
                           "test2@gmail.com",
                           "Магазин материалов",
                           "ул. Ленина 10",
                           "+79826534244",
                           20);
        Console.WriteLine($"\tПервый магазин\n{s1}");
        Console.WriteLine($"\tВторой магазин\n{s2}");

        Console.WriteLine($"s1 + 10: {(s1 + 10).Square}");
        Console.WriteLine($"s2 - 5: {(s2 - 5).Square}");
        Console.WriteLine($"s1 > s2: {s1 > s2}");
        Console.WriteLine($"s1 < s2: {s1 < s2}");
        Console.WriteLine($"s1 == s2: {s1 == s2}");
        Console.WriteLine($"s1 != s2: {s1 != s2}");
        Console.WriteLine($"s1.Equals(s2): {s1.Equals(s2)}");
    }
    static void StopProgram()
    {
        Console.Clear();
        Console.WriteLine("\n\t\tДо свидания!\n");
        Console.ReadKey();
    }
}
