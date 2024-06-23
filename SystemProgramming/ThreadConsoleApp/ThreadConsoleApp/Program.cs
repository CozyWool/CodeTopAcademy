var t = new Thread(WriteYWithParam); // Kick off a new thread
t.IsBackground = true;
t.Start(10000); // running WriteY()

// Simultaneously, do something on the main thread.
for (var i = 0; i < 10; i++)
    Console.Write("x");

static void WriteY()
{
    for (var i = 0; i < 1000; i++) 
        Console.Write("y");
}
static void WriteYWithParam(object obj)
{
    if (obj is not int count)
    {
        Console.WriteLine("Invalid argument");
        return;
    }
    for (var i = 0; i < count; i++) 
        Console.Write("y");
}