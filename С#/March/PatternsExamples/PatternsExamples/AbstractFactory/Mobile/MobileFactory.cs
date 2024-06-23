using PatternsExamples.AbstractFactory.Abstractions;
using PatternsExamples.AbstractFactory.Factories;

namespace PatternsExamples.AbstractFactory.Mobile
{
    internal class MobileFactory : IUiFactory
    {
        public IButton CreateButton() => new MobileButton();

        public ITextBox CreateTextBox() => new MobileTextBox();

        public IWindow CreateWindow() => new MobileWindow();
    }
}