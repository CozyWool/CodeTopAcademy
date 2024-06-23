namespace SyncConsoleApp;

public class MonitorLockCounter
{
    private readonly object _lock = new object();
    private readonly object _lock2 = new object();
    private int _field1, _field2;
    public int Field1 => _field1;
    public int Field2 => _field2;

    public void UpdateFields()
    {
        for (int i = 0; i < 1_000_000; i++)
        {
            lock (_lock)
            {
                ++_field1;
                if (_field1 % 2 == 0)
                    ++_field2;
            }
        }
    }

    public void UpdateFieldsMonitor()
    {
        bool lockTaken = false;
        for (int i = 0; i < 1_000_000; i++)
        {
            if (Monitor.TryEnter(this, 100))
            {
                // Monitor.Enter(this, ref lockTaken)
                // Monitor.Enter(this) - ждать бесконечно
                try
                {
                    ++_field1;
                    if (_field1 % 2 == 0)
                        ++_field2;
                }
                finally
                {
                    Monitor.Exit(this);
                }
            }
        }
    }

    public void DeadLockUpdateFields()
    {
        new Thread(() =>
        {
            for (var i = 0; i < 1000; i++)
            {
                lock (_lock)
                {
                    Thread.Sleep(1000);
                    Console.WriteLine("первый поток");
                    lock (_lock2)
                    {
                    }
                }
            }
        }).Start();

        lock (_lock2)
        {
            for (var i = 0; i < 1000; i++)
            {
                Thread.Sleep(1000);
                Console.WriteLine("второй поток");
                lock (_lock)
                {
                }
            }
        }
    }
}