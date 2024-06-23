using System;
using Patterns.AbstractFactory;
using Patterns.AbstractFactory.Enums;
using Patterns.Builder;
using Patterns.MacOS;
using Patterns.Mobile;
using Patterns.WinOS;

namespace Patterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //AbstractFactoryExample(OperationTypes.WinOS);
            BuilderExample();
        }


        private static AbstractUIFactory FactoryMethod(OperationTypes type)
        {
            AbstractUIFactory factory = null;
            switch (type)
            {
                case OperationTypes.Windows:
                    factory = new WinOSFactory();
                    break;
                case OperationTypes.MacOS:
                    factory = new MacOSFactory();
                    break;
                case OperationTypes.Mobile:
                    factory = new MobileFactory();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }

            return factory;
        }
        private static void AbstractFactoryExample(OperationTypes type)
        {
            var factory = FactoryMethod(type);
            var window = factory.CreateWindow();
            window.Title = "Окно приложения";
            window.Height = 100;
            window.Width = 200;
            Console.WriteLine($"Создано окно: {window.Title}, Ширина = {window.Width}, Высота = {window.Height}");
        }
        private static void BuilderExample()
        {
            Console.WriteLine("Создаем комплектацию компьютера");
            ComputerBuilder builder = new ComputerBuilder();
            var result = builder.AddMouse("SteelSeries").AddKeyboard("Mircosoft").AddMonitor("Samsung").Build();
            Console.WriteLine(result);
        }
    }
}
