using PersonLibrary;
using WrapperLib;

//PersonExample();
UnmanagedExample();

static void PersonExample()
{
    Person p = new("Иван", "Иванов", 42);
    p.Print();
}

static void UnmanagedExample()
{
    var result = SimpleLibraryWrapper.add(5, 8);
    var fibResult = SimpleLibraryWrapper.Fibonachi(3);
    Console.WriteLine(result);
    Console.WriteLine(fibResult);
}
