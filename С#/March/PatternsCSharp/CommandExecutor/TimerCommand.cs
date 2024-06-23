public class TimerCommand : ConsoleCommand
{
    public TimerCommand() : base("timer") { }

    public override void Execute(string[] args)
    {
        var timeout = TimeSpan.FromMilliseconds(int.Parse(args[1]));
        Console.WriteLine("Waiting for " + timeout);
        Thread.Sleep(timeout);
        Console.WriteLine("Done!");
    }
}
