using PatternsExamples.AbstractFactory.Abstractions;
using PatternsExamples.AbstractFactory.Enums;

namespace PatternsExamples.AbstractFactory.WinOs
{
    internal class WinOsTextBox : ITextBox
    {
        public OperationTypes Type => OperationTypes.Windows;
    }
}