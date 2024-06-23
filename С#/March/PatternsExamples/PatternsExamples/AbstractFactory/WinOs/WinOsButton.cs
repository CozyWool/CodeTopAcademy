using PatternsExamples.AbstractFactory.Abstractions;
using PatternsExamples.AbstractFactory.Enums;

namespace PatternsExamples.AbstractFactory.WinOs
{
    internal class WinOsButton : IButton
    {
        public OperationTypes Type => OperationTypes.Windows;
    }
}