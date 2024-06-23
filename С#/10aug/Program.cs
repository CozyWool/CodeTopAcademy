//GarbageCollectorExample();

FinalizeExample finalizeExample = new();
try
{
    finalizeExample.ExplicitThrow();
}
finally
{
    finalizeExample.Dispose();
}
//FinalizeExample finalizeExample = new();
//Console.WriteLine(finalizeExample);
//GC.Collect();
//Console.ReadLine();

static void GarbageCollectorExample()
{
    Console.WriteLine($"Максимальное поколение: {GC.MaxGeneration}");
    Console.WriteLine($"Занято памяти: {GC.GetTotalMemory(false)}");
    Console.WriteLine();

    var helper = new GarbageHelper();
    Console.WriteLine($"Занято памяти: {GC.GetTotalMemory(false)}");
    Console.WriteLine($"Поколение объекта: {GC.GetGeneration(helper)}");
    Console.WriteLine();


    helper.MakeGarbage(1000);
    Console.WriteLine($"Занято памяти после создания мусора: {GC.GetTotalMemory(false)}");
    Console.WriteLine();


    GC.Collect(0);
    Console.WriteLine($"Занято памяти после уборки мусора 0 поколения: {GC.GetTotalMemory(false)}");
    Console.WriteLine($"Поколение объекта: {GC.GetGeneration(helper)}");
    Console.WriteLine();


    GC.Collect();
    Console.WriteLine($"Занято памяти после уборки мусора всех поколений: {GC.GetTotalMemory(false)}");
    Console.WriteLine($"Поколение объекта: {GC.GetGeneration(helper)}");
    Console.WriteLine();
    Console.ReadLine();
}
