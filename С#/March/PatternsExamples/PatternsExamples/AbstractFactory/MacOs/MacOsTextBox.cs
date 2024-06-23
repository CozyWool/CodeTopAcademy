using PatternsExamples.AbstractFactory.Abstractions;
using PatternsExamples.AbstractFactory.Enums;

namespace PatternsExamples.AbstractFactory.MacOs
{
    internal class MacOsTextBox : ITextBox
    {
        public OperationTypes Type => OperationTypes.MacOs;
    }
}