public class PrintTimeCommand : ConsoleCommand
{
    public PrintTimeCommand() : base("printtime") { }

    public override void Execute(string[] args)
    {
        Console.WriteLine(DateTime.Now);
    }
}
