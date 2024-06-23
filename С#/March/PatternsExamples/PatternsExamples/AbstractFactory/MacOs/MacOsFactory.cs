using PatternsExamples.AbstractFactory.Abstractions;
using PatternsExamples.AbstractFactory.Factories;

namespace PatternsExamples.AbstractFactory.MacOs
{
    internal class MacOsFactory : IUiFactory
    {
        public IButton CreateButton() => new MacOsButton();

        public ITextBox CreateTextBox() => new MacOsTextBox();

        public IWindow CreateWindow() => new MacOsWindow();
    }
}