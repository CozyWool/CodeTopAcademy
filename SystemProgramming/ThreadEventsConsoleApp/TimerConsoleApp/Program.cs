var t = new Timer(TimerCallBack, null, TimeSpan.Zero, TimeSpan.FromSeconds(1));

Console.WriteLine("Работает основной поток");
Thread.Sleep(5000);
Console.WriteLine("Нажмите любую клавишу");
Console.ReadKey();
t.Dispose();

static void TimerCallBack(object? obj)
{
    Console.WriteLine($"Поток {Environment.CurrentManagedThreadId}: {DateTime.Now}");
}