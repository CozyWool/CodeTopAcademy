public abstract class ConsoleCommand
{
    protected ConsoleCommand(string name)
    {
        Name = name;
    }

    public string Name { get; }

    public abstract void Execute(string[] args);
}
