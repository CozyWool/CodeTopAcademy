using PatternsExamples.AbstractFactory.Abstractions;

namespace PatternsExamples.AbstractFactory.Factories
{
    internal interface IUiFactory
    {
        IWindow CreateWindow();
        IButton CreateButton();
        ITextBox CreateTextBox();
    }
}