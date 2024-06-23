Example1();
Console.ReadLine();

// static void Example1()
// {
//     LoadData();
//     Thread.Sleep(2000);
//     Console.WriteLine("Вывели сообщения после выполнения LoadData");
// }
//
// static void LoadData()
// {
//     Thread.Sleep(2000);
//     Console.WriteLine("LoadData. Вывод данных");
// }

static void Example1()
{
    LoadData().Wait();
    Thread.Sleep(2000);
    Console.WriteLine("Вывели сообщения после выполнения LoadData");
}

static async Task LoadData()
{
    Thread.Sleep(2000);
    await ShowAsync();
    Console.WriteLine("LoadData. Вывод данных");
}

static async Task ShowAsync()
{
    await Task.Delay(2000);
    Console.WriteLine("Вывод информации....");
}