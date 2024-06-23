// Example1();
// Example2();
// Example3();
// Example4();
// Example5();

Example6();


static void Example1()
{
    Task.Run(() => Console.WriteLine("Hello"));
    Task.Delay(1000).Wait();
    Console.WriteLine("World");
    Console.ReadKey();
}

static void Example2()
{
    var task = Task.Run(() =>
    {
        Thread.Sleep(1000);
        Console.WriteLine("Hello");
    });

    Console.WriteLine(task.IsCompleted);
    task.Wait();
    // await task.WaitAsync(TimeSpan.FromSeconds(2));
    Console.WriteLine(task.IsCompleted);
}

static void Example3()
{
    var chars = "abcdef".ToCharArray();
    var result = chars.AsParallel<char>()
        .Select(char.ToUpper)
        // .Select(ch => char.ToUpper(ch))
        .ToArray();
    var resultStr = new string(result);
    Console.WriteLine(resultStr);
}

static void Example4()
{
    var task = Task.Run<int>(() =>
    {
        var k = 0;

        for (var i = 2; i <= 10; i++)
        {
            var isPrime = true;
            for (var j = 2; j <= (int) Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                {
                    isPrime = false;
                    break;
                }
            }

            if (isPrime) k++;
        }

        return k;
    });

    // task.Wait(); // не обязательно
    Console.WriteLine(task.Result);
}

static void Example5()
{
    try
    {
        var task = new Task(() => throw new NullReferenceException("Ошибочка вышла...."));
        task.Start();
        task.Wait();
    }
    catch (AggregateException exception)
    {
        if (exception.InnerException is NullReferenceException)
        {
            Console.WriteLine($"null excepetion with msg: {exception.InnerException.Message}");
        }
        else
        {
            throw;
        }
    }
}

static void Example6()
{
    var task = Task.Run(() =>
    {
        const int start = 2;
        const int end = 3_000_000;
        var count = 0;
        for (var i = start; i < end; i++)
        {
            var flag = true;
            for (var j = 2; j <= Math.Sqrt(i); j++)
            {
                if (i % j == 0)
                {
                    flag = false;
                    //Console.Write($"{i} ");
                    break;
                }
            }

            if (flag) count++;
        }

        //Console.WriteLine();
        return count;
    });

    var okTask = task.ContinueWith(x => { Console.WriteLine(x.Result); }, TaskContinuationOptions.OnlyOnRanToCompletion); // Если все получилось
    var errorTask = task.ContinueWith(x => { Console.WriteLine(x.Exception); }, TaskContinuationOptions.OnlyOnFaulted); // Только при ошибке

    // Task.WaitAny(okTask, errorTask);
    // if (!okTask.IsCompletedSuccessfully)
    // {
    //     Console.WriteLine("Task выполнился с ошибкой....");
    // }
    try
    {
        Task.WaitAll(okTask, errorTask);
    }
    catch (AggregateException exception)
    {
        Console.WriteLine(exception.InnerException);
    }
}