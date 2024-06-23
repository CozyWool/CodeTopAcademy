var are = new AutoResetEvent(false);
var handle = ThreadPool.RegisterWaitForSingleObject(are, EventOperation, null, 5000, false);


char operation;
Console.WriteLine("S=Signal, Q=Quit");
do
{
    operation = char.ToUpper(Console.ReadKey(true).KeyChar);
    if (operation == 'S')
    {
        are.Set();
    }
} while (operation != 'Q');

handle.Unregister(null);

static void EventOperation(object? state, bool timedOut)
{
    Console.WriteLine(timedOut ? "Время ожидания истекло." : $"Поток {Environment.CurrentManagedThreadId} отработал");
}