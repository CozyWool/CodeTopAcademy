

/*
try
{
    код, в котором возможно возникает исключение
}
catch (тип_исключения)
{
    обработка исключения
}
catch (тип_исключения) when (условие)
{
    обработка исключения
}
finally
{
    выполняется в любом случае
}
*/

using System.Text;

try
{
    //ExceptionsExample();
    //OverFlowExample();
    //CheckedUncheckedExample();
    //NameOfExample();
    //WriteFileStreamExample();
    //ReadFileStreamExample();
    StreamReaderExample();
    BinaryWriterExample();
    //StreamWriterExample();
}
catch (Exception ex)
{
    Console.WriteLine($"Исключение обработал catch над методом FirstExample {ex}");
}


static void ExceptionsExample()
{
    try
    {
        Console.WriteLine("Введите два числа:");
        var numberOne = int.Parse(Console.ReadLine());
        var numberTwo = int.Parse(Console.ReadLine());
        var result = numberOne / numberTwo;
        Console.WriteLine($"Результат: {result}");
        //Console.WriteLine("Выбросить MyException? 1 - да, 0 - нет");
        //var isThrow = int.Parse(Console.ReadLine());
        //if (isThrow == 1)
        //{
        //    throw new MyException();
        //}
        Console.WriteLine("Выбросить DivideNumbersException? 1 - да, 0 - нет");
        var isThrow = int.Parse(Console.ReadLine());
        if (isThrow == 1)
        {
            throw new DivideNumbersException(numberOne, numberTwo);
        }
    }
    catch (DivideNumbersException exception) when (exception.NumberOne == 3 && exception.NumberTwo == 5)
    {
        Console.WriteLine($"Первый блок: {exception}");
    }
    catch (DivideNumbersException exception)
    {
        Console.WriteLine($"Второй блок: {exception}");
    }
    catch (DivideByZeroException exception)
    {
        //Console.WriteLine($"Message: {exception.Message}. Stack Trace: {exception.StackTrace}");
        Console.WriteLine($"{exception}");
    }
    catch (MyException exception)
    {
        Console.WriteLine($"Message: {exception.Message}");
    }

    catch (Exception exception)
    {
        Console.WriteLine($"{exception.Message}");
        throw new MyException("Мы обернули исключение в наше собственное", exception);
    }
    finally
    {
        Console.WriteLine($"Этот блок всегда выполняется");
    }
}

static void OverFlowExample()
{
    byte b = 100;
    b = (byte)(b + 200);
    Console.WriteLine(b);
}
static void CheckedUncheckedExample()
{
    // checked unchecked
    try
    {
        byte b = 100;
        checked
        {
            b = (byte)(b + 200);
        }
        Console.WriteLine(b);
    }
    catch (OverflowException ex)
    {
        Console.WriteLine(ex.Message);
    }

}
static void NameOfExample(string name = null)
{
    if (name == null)
    {
        throw new ArgumentNullException(nameof(name));
    }
}

static void WriteFileStreamExample()
{
    var fs = new FileStream("test.txt", FileMode.Create, FileAccess.Write);
    string text = "Hello file!!!";
    var buffer = Encoding.UTF8.GetBytes(text);
    fs.Write(buffer, 0, buffer.Length);
    fs.Close();
}
static void ReadFileStreamExample()
{
    var fs = new FileStream("test.txt", FileMode.Open, FileAccess.Read);
    var buffer = new byte[50];
    while (fs.Position < fs.Length)
    {
        int count = fs.Read(buffer, 0, buffer.Length);
        var text = Encoding.UTF8.GetString(buffer, 0, count);
        Console.WriteLine(text);
    }
    fs.Close();
}

static void StreamReaderExample()
{
    var sr = new StreamReader("test.txt", Encoding.UTF8);

    while (!sr.EndOfStream)
    {
        var text = sr.ReadLine();
        Console.WriteLine($"{text}");
    }

    sr.Close();
}
static void StreamWriterExample()
{
    var sw = new StreamWriter("test.txt", true, Encoding.UTF8);
    sw.WriteLine("Еще одна строка текста...");
    sw.Close();
}
static void BinaryWriterExample()
{
    var fs = new FileStream("test.txt", FileMode.Create, FileAccess.Write);
    var bw = new BinaryWriter(fs);
    bw.Write(true);
    bw.Write(55);
    bw.Write(3.14);
    bw.Write("test.");
    bw.Close();
}