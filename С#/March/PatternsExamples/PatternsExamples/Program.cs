using System;
using PatternsExamples.AbstractFactory.Enums;
using PatternsExamples.AbstractFactory.Factories;
using PatternsExamples.AbstractFactory.MacOs;
using PatternsExamples.AbstractFactory.Mobile;
using PatternsExamples.AbstractFactory.WinOs;
using PatternsExamples.Builder;

namespace PatternsExamples
{
    class Program
    {
        static void Main(string[] args)
        {
            AbstractFactoryExample();
            BuilderExample();
        }

        private static void AbstractFactoryExample()
        {
            //IWindow (width, height, IButton, ITextBox)
            //IButton
            //ITextBox

            //WinWindow, MacOsWindow, MobileWindow
            //WinButton, MacOsButton, MobileButton
            //WinTextBox, MacOsTextBox, MobileTextBox

            /* old variant, without AbstractFactory
            var logger = new ConsoleLogger();
            IWindow window = new MacOsWindow(logger);
            IButton button = new WinOsButton();
            ITextBox textBox = new WinOsTextBox();*/

            //with AbstractFactory
            /*var logger = new ConsoleLogger();
            var factory = new MobileFactory();
            IWindow window = factory.CreateWindow(logger);
            IButton button = factory.CreateButton();
            ITextBox textBox = factory.CreateTextBox();*/

            //with GenericAbstractFactory and Factory method
            var factory = CreateFactory(OperationTypes.MacOs);
            var window = factory.CreateWindow();
            var button = factory.CreateButton();
            var textBox = factory.CreateTextBox();
            window.AddElement(button);
            window.AddElement(textBox);
        }

        private static void BuilderExample()
        {
            Console.WriteLine("Создаем комплектацию компьютера");
            var builder = new ComputerBuilder();
            var result = builder
                .AddMouse("logitech")
                .AddKeyboard("microsoft")
                .AddMonitor("Dell")
                .Build();
            Console.WriteLine(result);
        }

        //Factory method
        private static IUiFactory CreateFactory(OperationTypes type)
        {
            switch (type)
            {
                case OperationTypes.Windows:
                    return new GenericUiFactory<WinOsWindow, WinOsButton, WinOsTextBox>();
                case OperationTypes.MacOs:
                    return new GenericUiFactory<MacOsWindow, MacOsButton, MacOsTextBox>();
                case OperationTypes.Mobile:
                    return new GenericUiFactory<MobileWindow, MobileButton, MobileTextBox>();
                default:
                    throw new ArgumentOutOfRangeException(nameof(type));
            }
        }
    }
}