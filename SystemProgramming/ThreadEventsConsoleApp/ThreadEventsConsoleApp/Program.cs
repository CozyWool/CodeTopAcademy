const int count = 15;
// var mre = new ManualResetEvent(true);

var are = new AutoResetEvent(true);
//are.Set();

// Console.WriteLine("Событие с ручным сбросом");
Console.WriteLine("Событие с авто сбросом");
for (var i = 0; i < count; i++)
{
    // ThreadPool.QueueUserWorkItem(ManualResetExample, mre);
    ThreadPool.QueueUserWorkItem(WaitResetExample, are);
}

Console.WriteLine("Все потоки были добавлены в очередь. Чтобы завершить, нажмите любую клавишу");

Console.ReadKey();

static void WaitResetExample(object obj)
{

    var ev = obj as EventWaitHandle;
    if (ev.WaitOne(10))
    {
        Console.WriteLine($"Поток {Environment.CurrentManagedThreadId} успел проскочить");
        //Thread.Sleep(10);
        // ev.Reset();
        ev.Set();
    }
    else
    {
        Console.WriteLine($"Поток {Environment.CurrentManagedThreadId} опоздал");
    }
}