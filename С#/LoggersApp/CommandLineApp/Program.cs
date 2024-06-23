using CommandLine;

internal class Program
{
    private static void Main(string[] args)
    {
        Parser.Default.ParseArguments<ArithmeticOptions,ParseOptions>(args)
            .MapResult(
                (ArithmeticOptions opts) => RunArithmetic(opts),
                (ParseOptions opts) => RunParse(opts),
                error => 1
            );
    }

    private static int RunParse(ParseOptions opts)
    {
        foreach (var arg in opts.Text.Split(' '))
        {
            Console.WriteLine(arg);
        }
        return 0;
    }

    private static int RunArithmetic(ArithmeticOptions opts)
    {
        switch (opts.OperationType)
        {
            case OperationTypes.Addtion:
                Console.WriteLine(opts.FirstNumber + opts.SecondNumber);
                break;
            case OperationTypes.Substract:
                Console.WriteLine(opts.FirstNumber - opts.SecondNumber);
                break;
            default:
                break;
        }
        return 0;
    }
}

public enum OperationTypes
{
    Addtion,
    Substract
}
[Verb("arithmetic",HelpText ="Укажите операцию +/- и два операнда")]
public class ArithmeticOptions
{
    public OperationTypes OperationType { get; set; }
    public int FirstNumber { get; set; }
    public int SecondNumber { get; set; }
}

[Verb("parse", HelpText = "Введите предложение")]
public record ParseOptions
{
    public string Text{ get; set; }
}