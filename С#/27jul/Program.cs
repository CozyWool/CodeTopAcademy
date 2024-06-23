//delegate [(параметры)]
//{
//    // код
//}

internal class Program
{
    private static void Main(string[] args)
    {
        Example example = new Example();

        example.show = delegate (string text)
        {
            Console.WriteLine(text);
        };

        example.show += (text) => Console.WriteLine(text);
        example.Test("Тестовое сообщение");
    }
}