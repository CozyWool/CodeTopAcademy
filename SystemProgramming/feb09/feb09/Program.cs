Console.WriteLine(Environment.ProcessorCount);
var threads = new Thread[Environment.ProcessorCount];
var manualResetEvents = new ManualResetEvent[Environment.ProcessorCount];
for (var i = 0; i < threads.Length; i++)
{
    manualResetEvents[i] = new ManualResetEvent(false);
    threads[i] = new Thread(() =>
    {
        for (int j = 0; j < 1000; j++)
        {
            Console.WriteLine($"Thread = {Thread.CurrentThread.Name}, {j++}");
        }

        manualResetEvents[i].Set();
    });
    threads[i].Name = $"Thread №{i}";
    threads[i].IsBackground = false;
}

for (var i = 0; i < threads.Length; i++)
{
    threads[i].Start();
};
// for (int i = 0; i < threads.Length; i++)
// {
//     threads[i].Join();
// } ->
WaitHandle.WaitAll(threads);