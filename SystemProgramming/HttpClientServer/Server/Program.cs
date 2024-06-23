using Server;

internal class Program
{
    private static async Task Main(string[] args)
    {
        var server = new HttpServer(1234);
        _ = Task.Run(server.Start);
        
        Console.WriteLine("Запускаем сервер. Слушаем порт 1234");
        Console.WriteLine("Нажмите Enter, чтобы остановить сервер.");
        Console.ReadLine();
        await server.Stop();
        Console.WriteLine("Сервер заверишл работу.");
    }
}
