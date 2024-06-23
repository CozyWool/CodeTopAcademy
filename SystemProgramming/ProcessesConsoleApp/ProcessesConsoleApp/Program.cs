using System.Diagnostics;

Example2();

static void Example1()
{
    var processes = Process.GetProcesses();
    foreach (var p in processes)
    {
        Console.WriteLine($"{p.ProcessName}-{p.BasePriority}-{p.Id}");
    }
}
static void Example2()
{
    Process process = new Process();
    process.StartInfo.FileName = "notepad.exe";
    process.Start();
    Console.WriteLine($"Запущенный процесс: {process.ProcessName}");
    process.WaitForExit();
    Console.WriteLine($"Код завершения процесса: {process.ExitCode}");
    Console.WriteLine($"{Process.GetCurrentProcess().ProcessName}");
    Console.ReadLine();
}