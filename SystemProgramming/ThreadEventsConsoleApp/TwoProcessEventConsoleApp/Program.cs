internal class Program
{
    private static EventWaitHandle _handle;
    private static int _result;

    private static void Main()
    {
        try
        {
            _handle = EventWaitHandle.OpenExisting("Process_event");
            _handle.Set();
            _result = 2;
        }
        catch (WaitHandleCannotBeOpenedException ex)
        {
            _handle = new EventWaitHandle(false, EventResetMode.AutoReset, "Process_event");
            _result = 1;
            Console.WriteLine("Запустите второй экземпляр приложения....");
        }

        ThreadPool.QueueUserWorkItem(ThreadMethod);
        Console.ReadKey();
    }

    private static void ThreadMethod(object? state)
    {
        _handle.WaitOne();
        Thread.Sleep(TimeSpan.FromSeconds(1));
        Console.WriteLine($"Поток {Environment.CurrentManagedThreadId}: Результат = {_result}");
        _result += 2;
        _handle.Set();
        Thread.Sleep(TimeSpan.FromSeconds(1));
        if (_result <= 10)
            ThreadPool.QueueUserWorkItem(ThreadMethod);
    }
}