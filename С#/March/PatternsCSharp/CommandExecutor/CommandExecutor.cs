public class CommandExecutor
{
    private readonly List<ConsoleCommand> commands = new List<ConsoleCommand>();
    public void Register(ConsoleCommand command)
    {
        commands.Add(command);
    }
    public string[] GetAvailableCommands()
    {
        var names = new List<string>();
        foreach (var item in commands) 
            names.Add(item.Name);
        return names.ToArray();
    }
    public void Execute(string[] args)
    {
        if (args.Length == 0)
            Console.WriteLine("Please specify <command> as the first command line argument");
        var command = args[0];
        var cmds = commands.Where(x => x.Name == command).ToList();

        if (cmds.Count == 0) Console.WriteLine("Sorry. Unknown command {0}", command);
        else cmds[0].Execute(args);
    }
            
}
