using PatternsExamples.AbstractFactory.Abstractions;
using PatternsExamples.AbstractFactory.Factories;

namespace PatternsExamples.AbstractFactory.WinOs
{
    internal class WinOsFactory : IUiFactory
    {
        public IButton CreateButton() => new WinOsButton();

        public ITextBox CreateTextBox() => new WinOsTextBox();

        public IWindow CreateWindow() => new WinOsWindow();
    }
}