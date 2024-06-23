using MorseCode;

public class Program
{
    private static void Main(string[] args)
    {
        while (true)
        {
            Console.Write("Введите номер задания(3 - 4, 0 - выход из программы): ");
            string t = Console.ReadLine();
            Console.Clear();
            switch (t)
            {
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

    private static void ThirdTask()
    {
        Console.Write("Введите текст для перевода в азбуку Морзе: ");
        string? input = Console.ReadLine();
        Console.Write("Ваш текст на русском?(Y/N) ");
        bool answer = Console.ReadLine().ToUpper() == "Y";
        string morse = MorseCodeTranslator.TranslateToMorse(input,answer);
        Console.WriteLine($"Ваш текст в азбуке Морзе: {morse}");
    }

    private static void FourthTask()
    {
        Console.Write("Введите текст в азбуке Морзе для перевода в обычный текст (буквы отделяются одним пробелом, слова - двумя): "); 
        string? input = Console.ReadLine();
        Console.Write("Ваш текст на русском?(Y/N): ");
        bool answer = Console.ReadLine().ToUpper() == "Y";
        string text = MorseCodeTranslator.TranslateToText(input, answer);
        Console.WriteLine($"Ваш текст: {text}");
    }

    static void StopProgram()
    {
        Console.Clear();
        Console.WriteLine("\n\t\tДо свидания!\n");
        Console.ReadKey();
    }
}
