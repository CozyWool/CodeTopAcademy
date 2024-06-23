// Example1();

Example2();

static void Example1()
{
    const int count = 5;
    var threads = new Thread[count];
    var waitHandles = new EventWaitHandle[count];


    for (var i = 0; i < count; i++)
    {
        threads[i] = new Thread(Work);
        waitHandles[i] = new ManualResetEvent(false);
    }

    var random = new Random();
    for (var i = 0; i < count; i++)
    {
        threads[i].Start(new WorkData {SleepTime = random.Next(3, 10), Handle = waitHandles[i]});
    }

    Console.WriteLine("Ждем завершения потоков");
    WaitHandle.WaitAll(waitHandles);
    Console.WriteLine("Потоки выполнили работу");
}

static void Work(object? obj)
{
    if (obj is not WorkData workData)
    {
        return;
    }


    var sleepTime = workData.SleepTime;
    Console.WriteLine($"Поток {Environment.CurrentManagedThreadId} начал работу со временем {sleepTime} секунды");

    Thread.Sleep(TimeSpan.FromSeconds(sleepTime));

    Console.WriteLine($"Поток {Environment.CurrentManagedThreadId} закончил работу");
    workData.Handle.Set();
}

static void Example2()
{
    const int count = 5;
    var threads = new Thread[count];
    var waitHandles = new EventWaitHandle[count];


    for (var i = 0; i < count; i++)
    {
        threads[i] = new Thread(Work);
        waitHandles[i] = new ManualResetEvent(false);
    }

    var random = new Random();
    for (var i = 0; i < count; i++)
    {
        threads[i].Start(new WorkData {SleepTime = random.Next(3, 10), Handle = waitHandles[i]});
    }

    Console.WriteLine("Ждем завершения любого потока");
    var index = WaitHandle.WaitAny(waitHandles);
    Console.WriteLine($"Поток с индексом {index} (id = {threads[index].ManagedThreadId}) завершил первым работу");
}

internal class WorkData
{
    public int SleepTime { get; set; }
    public EventWaitHandle Handle { get; set; }
}