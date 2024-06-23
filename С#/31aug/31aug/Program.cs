using _31aug.FirstTask;
using _31aug.SecondTask;

while (true)
{
    Console.Write("Введите номер задания(1 - 3, 0 - выход из программы): ");
    string t = Console.ReadLine();
    Console.Clear();
    switch (t)
    {
        case "1":
            FirstTask();
            break;
        case "2":
            SecondTask();
            break;
        case "3":
            ThirdTask();
            break;
        case "0":
            StopProgram();
            return;
        default:
            break;
    }
}

static void FirstTask()
{
    Person person = new("Alex",30);
    person.PropertyChanged += Person_PropertyChanged;
    person.Age = 31;
    person.Name = "John";
}

static void Person_PropertyChanged(object sender, PropertyEventArgs e)
{
    if (sender is Person p)
    {
        Console.WriteLine($"Внешняя функция: у {p.Name} изменилось свойство {e.PropertyName}");
    }
}

static void SecondTask()
{
    Product ham = new("Колбаса", 10);
    Product milk = new("Молоко", 20);
    Product cheese = new("Сыр", 30);
    Client client = new("John", 100);
    Dictionary<Product, int> products = new()
    {
        { ham, 2 },
        { milk, 1 },
        { cheese, 0 }
    };
    Shop shop = new("Пятерочка", "Продуктовый магазин", products);
    Console.WriteLine($"\tМагазин\n{shop}");
    Console.WriteLine($"\tКлиент\n{client}");
    client.BuyProduct(shop, milk);
    client.BuyProduct(shop, ham);
    client.BuyProduct(shop, cheese);

    Console.WriteLine($"\n--------------------------\n\tМагазин\n{shop}");
    Console.WriteLine($"\tКлиент\n{client}\n--------------------------");

    shop.IncreaseProduct(cheese, 2);

    Console.WriteLine($"\n--------------------------\n\tМагазин\n{shop}");
    Console.WriteLine($"\tКлиент\n{client}\n--------------------------");

}
static void ThirdTask()
{
}
static void StopProgram()
{
    Console.Clear();
    Console.WriteLine("\n\t\tДо свидания!\n");
    Console.ReadKey();
}