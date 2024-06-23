using PatternsExamples.AbstractFactory.Abstractions;

namespace PatternsExamples.AbstractFactory.Factories
{
    internal class GenericUiFactory<TWindow, TButton, TTextBox> : IUiFactory
        where TWindow : IWindow, new()
        where TButton : IButton, new()
        where TTextBox : ITextBox, new()
    {
        public IWindow CreateWindow() => new TWindow();
        public IButton CreateButton() => new TButton();
        public ITextBox CreateTextBox() => new TTextBox();
    }
}