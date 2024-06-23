using PatternsExamples.AbstractFactory.Enums;

namespace PatternsExamples.AbstractFactory.Abstractions
{
    internal interface IWindow
    {
        OperationTypes Type { get; }

        int Width { get; set; }

        int Height { get; set; }

        void AddElement(IButton button);
        void AddElement(ITextBox textBox);
    }
}