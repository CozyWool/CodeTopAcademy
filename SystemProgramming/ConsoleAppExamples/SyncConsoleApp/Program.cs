using System.Collections.Concurrent;
using SyncConsoleApp;

// Example1();
// Example2();
// Example3();
// Example4();
Example6();

static void Example1()
{
    int counter = 0;
    int threadCount = 5;
    var threads = new Thread[threadCount];
    for (int i = 0; i < threadCount; i++)
    {
        threads[i] = new Thread(() =>
        {
            for (int i = 0; i < 1_000_000; i++)
            {
                // counter++;
                Interlocked.Increment(ref counter);
            }
        });
    }

    for (int i = 0; i < threadCount; i++)
    {
        threads[i].Start();
    }

    for (int i = 0; i < 1_000_000; i++)
    {
        // counter++;
        Interlocked.Increment(ref counter);
    }

    for (int i = 0; i < threadCount; i++)
    {
        threads[i].Join();
    }

    Console.WriteLine($"counter = {counter}");
}

static void Example2()
{
    int value = 5;
    int val2 = value;
    value = 42;

    var p1 = new Person();
    var p2 = p1;
    p1.Id = 55;

    var counter = new MonitorLockCounter();
}

static void Example3()
{
    var counter = new MonitorLockCounter();
    counter.DeadLockUpdateFields();
}

static void Example4()
{
    var value = 0;
    Mutex mutex = new Mutex();

    var thread1 = new Thread(() =>
    {
        mutex.WaitOne();
        value += 10;
        Thread.Sleep(TimeSpan.FromSeconds(3));
        mutex.ReleaseMutex();
    });
    var thread2 = new Thread(() =>
    {
        mutex.WaitOne();
        value += 15;
        Thread.Sleep(TimeSpan.FromSeconds(3));
        mutex.ReleaseMutex();
    });

    thread1.Start();
    thread2.Start();

    thread1.Join();
    thread2.Join();
    Console.WriteLine($"{value}");
}

static void Example5()
{
    var obj = new object();
    var clientCount = 20;
    var threadCount = 5;
    var semaphore = new Semaphore(3, 3);
    var threads = new Thread[threadCount];
    for (int i = 0; i < threadCount; i++)
    {
        var temp = i;
        threads[i] = new Thread(() =>
            {
                while (true)
                {
                    var clientNumber = 0;
                    lock (obj)
                    {
                        clientNumber = clientCount--;
                        if (clientCount <= 0)
                        {
                            Console.WriteLine($"Thread {temp} has nothing to do");
                            return;
                        }
                    }
                    semaphore.WaitOne();
                    Console.WriteLine($"Thread {temp} started work with client #{clientNumber}");
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.WriteLine($"Thread {temp} ended work with client #{clientNumber}");
                    clientCount--;

                    semaphore.Release();
                }
            }
        );
    }

    for (int i = 0; i < threadCount; i++)
    {
        threads[i].Start();
    }
}
static void Example6()
{
    
    var clientCount = 20;
    var bag = new ConcurrentBag<int>();
    for (int i = 1; i <= clientCount; i++)
    {
        bag.Add(i);
    }
    var threadCount = 5;
    var semaphore = new Semaphore(3, 3);
    var threads = new Thread[threadCount];
    for (int i = 0; i < threadCount; i++)
    {
        var temp = i;
        threads[i] = new Thread(() =>
            {
                while (true)
                {
                    if (bag.IsEmpty)
                    {
                        Console.WriteLine($"Потоку {temp} нечего делать");
                        return;
                    }
                    
                    semaphore.WaitOne();
                    if (!bag.TryTake(out var clientNumber))
                    {
                        Console.WriteLine($"Поток {temp} не смог получить элемент для обработки");
                        continue;
                    }

                    
                    Console.WriteLine($"Поток {temp} начал работу с клиентом #{clientNumber}");
                    Thread.Sleep(TimeSpan.FromSeconds(1));
                    Console.WriteLine($"Поток {temp} обработал клиента #{clientNumber}");

                    semaphore.Release();
                }
            }
        );
    }

    for (int i = 0; i < threadCount; i++)
    {
        threads[i].Start();
    }
}