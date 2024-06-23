using PatternsCSharp.ChainOfResponsibility;
using PatternsCSharp.Decorator;
using PatternsCSharp.Observer;
using PatternsCSharp.Prototype;
using PatternsCSharp.Singleton;
using PatternsCSharp.Visitor;
using System;
using PatternsCSharp.Iterator;
using TemplatePizza = PatternsCSharp.Template;
using PatternsCSharp.Proxy;
using PatternsCSharp.Flyweight;

public class Program
{
    private static void Main(string[] args)
    {

        //var chessePizza = new ChessePizza();
        //var meatPizza = new MeatPizza(chessePizza);
        //PizzaBase pizza = new MeatPizza(meatPizza);
        //pizza.MakePizza();

        //var tomatoPizza = new TemplatePizza.TomatoPizza();
        //var meatPizza = new TemplatePizza.MeatPizza();
        //tomatoPizza.MakePizza();
        //meatPizza.MakePizza();

        //ChainOfResponsibilityExample();

        //PrototypeExample();

        //SingletonExample();

        //ObserverExample();

        //VisitorExample();

        //var executor = new CommandExecutor();
        //executor.Register(new HelpCommand());
        //executor.Register(new TimerCommand());
        //executor.Register(new PrintTimeCommand());
        //executor.Execute(args);

        //ProxyExample();

        FlyweightExample();
    }

    private static void ObserverExample()
    {
        //Наблюдатель, Observer, Слушатель, Издатель-Подписчик
        //var subscriber1 = new Subscriber("Петя");
        //var subscriber2 = new Subscriber("Вова");
        //var subscriber3 = new Subscriber("Катя");
        //var publisher = new Publisher();
        //publisher.AddSubscriber(subscriber1);
        //publisher.AddSubscriber(subscriber2);
        //publisher.AddSubscriber(subscriber3);
        //publisher.ProductArrvied("Книга \"Алгоритмы программирования\"");
        //Console.WriteLine();
        //publisher.RemoveSubscriber(subscriber2);
        //publisher.ProductArrvied("Книга \"Паттерны программирования\"");

        // Publisher on delegates
        var subscriber1 = new Subscriber("Петя");
        var subscriber2 = new Subscriber("Вова");
        var subscriber3 = new Subscriber("Катя");
        var publisher = new PublisherOnDelegate();
        publisher.Subscribers += subscriber1.NotifyMe;
        publisher.Subscribers += subscriber2.NotifyMe;
        publisher.Subscribers += subscriber3.NotifyMe;
        publisher.ProductArrvied("Книга \"Алгоритмы программирования\"");
        Console.WriteLine();
        publisher.Subscribers -= subscriber2.NotifyMe;
        publisher.ProductArrvied("Книга \"Паттерны программирования\"");
    }

    private static void SingletonExample()
    {
        var singleton1 = Singleton.GetInstance();
        var singleton2 = Singleton.GetInstance();
        singleton1.SetValue("5");
        singleton2.SetValue("6");
        Console.WriteLine($"Singleton1 = {singleton1.GetValue()}");
        Console.WriteLine($"Singleton2 = {singleton2.GetValue()}");

    }

    private static void PrototypeExample()
    {
        var p = new PatternsCSharp.Prototype.Person() { Id = 78, Name = "Иван" };
        var p2 = p.Clone() as PatternsCSharp.Prototype.Person;
        Console.WriteLine($"P1: {p.Id}, {p.Name}");
        Console.WriteLine($"P2: {p2.Id}, {p2.Name}");
        p.Id = 56;
        Console.WriteLine($"P1: {p.Id}, {p.Name}");
        Console.WriteLine($"P2: {p2.Id}, {p2.Name}");
    }

    private static void VisitorExample()
    {
        var figures = new Shape[]
        {
        new Circle(),
        new Rectangle(),
        new Rectangle(),
        new Circle(),
        new Circle(),
        };
        var visitor = new XmlExportVisitor();
        foreach (var figure in figures)
        {
            figure.Accept(visitor);
            figure.Accept2();
        }
    }

    private static void ChainOfResponsibilityExample()
    {
        var squirrel = new SquirrelHandler();
        var monkey = new MonkeyHandler();
        var dog = new DogHandler();

        squirrel.Next = monkey;
        monkey.Next = dog;

        var handler = squirrel;

        var collection = new[]
        {
        "Nut","Banana","Bone","Tomato"
    };
        foreach (var item in collection)
        {
            var result = handler.Handle(item);
            if (!result)
            {
                Console.WriteLine($"Nobody eat {item}");
            }
        }
    }

    private static void IteratorExample()
    {
        var friends = new VKFriendsCollection();
        friends.AddFriend(new PatternsCSharp.Iterator.Person { Name = "Федя" });
        friends.AddFriend(new PatternsCSharp.Iterator.Person { Name = "Петя" });
        friends.AddFriend(new PatternsCSharp.Iterator.Person { Name = "Саша" });
        friends.AddFriend(new PatternsCSharp.Iterator.Person { Name = "Катя" });

        // var 1
        Console.WriteLine("Variant 1");
        var enumerator = friends.GetEnumerator();
        while (enumerator.MoveNext())
        {
            var friend = enumerator.Current;
            Console.WriteLine(friend.Name);
        }

        // var2
        Console.WriteLine("Variant 1");
        foreach (var friend in friends)
        {
            Console.WriteLine(friend.Name);
        }
    }
    private static void ProxyExample()
    {
        ThingServer thingServer = new ThingServer();
        ThingCache thingCache = new ThingCache(thingServer);
        FindThing(thingCache);
    }
    private static void FindThing(IThingServer thingServer)
    {
        Console.WriteLine("Введите id предмета для поиска:");
        //var thingId = Console.ReadLine();
        var thingId = "2";
        if (thingServer.TryRead(thingId,out var thing)) 
        { 
            Console.WriteLine($"Вещь найдена: {thingId}, {thing.Name}, {thing.Description}");
        }
        else
        {
            Console.WriteLine($"Вещь с id = {thingId} не найдена");
        }
    }

    private static void FlyweightExample()
    {
        Sentence sentence = new("hello world");
        sentence[1].Capitalize = true;
        Console.WriteLine(sentence);
        sentence[0].Capitalize = true;
        sentence[1].Capitalize = false;
        Console.WriteLine(sentence);
    }


}