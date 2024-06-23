// Example1();

Example2();

static void Example1()
{
    Random r = new Random();
    Console.WriteLine("Основной поток. Ставим в очередь элемент");
    for (int i = 0; i < 15; i++)
    {
        ThreadPool.QueueUserWorkItem(state =>
        {
            Console.WriteLine($"\tпоток {Thread.CurrentThread.ManagedThreadId} = {state}");
            Thread.Sleep(TimeSpan.FromSeconds(1));
        }, r.Next(0, 10));
    }

    Console.WriteLine("Основной поток. Выполним другие задачи");
    Thread.Sleep(TimeSpan.FromSeconds(1));
    Console.WriteLine("Enter any key");
    Console.ReadKey();
}

static void Example2()
{
    CancellationTokenSource cts = new CancellationTokenSource();

    void HelloThreadMethod(object obj)
    {
        try
        {
            var workData = (WorkData) obj;
            var token = workData.Token;
            for (int i = 0; i < workData.Count; i++)
            {
                token.ThrowIfCancellationRequested();
                Console.WriteLine(
                    $"\t\t\tHello in thread {Environment.CurrentManagedThreadId} - {Thread.CurrentThread.ManagedThreadId}");
                Thread.Sleep(TimeSpan.FromSeconds(1));
            }
        }
        catch (OperationCanceledException ex)
        {
            Console.WriteLine($"Операция была отменена");
        }
        finally
        {
            Console.WriteLine($"Конец потока {Thread.CurrentThread.ManagedThreadId} work");
        }
    }

    var thread = new Thread(HelloThreadMethod);
    thread.IsBackground = true;
    thread.Priority = ThreadPriority.AboveNormal;
    thread.Start(new WorkData
    {
        Count = 20,
        Token = cts.Token
    });
    
    Console.WriteLine("Нажмите любую клавишу");
    Console.ReadKey();
    cts.Cancel();
    Console.ReadLine();
}

internal class WorkData
{
    public int Count { get; set; }
    public CancellationToken Token { get; set; }
}