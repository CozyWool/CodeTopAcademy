public class HelpCommand : ConsoleCommand
{
    public HelpCommand() : base("help") { }

    public override void Execute(string[] args)
    {
        Console.WriteLine("Available commands: ");
        foreach (var command in new[] { "timer", "printtime", "help" })
            Console.WriteLine(command);
    }
}
