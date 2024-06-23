using PatternsExamples.AbstractFactory.Abstractions;
using PatternsExamples.AbstractFactory.Enums;

namespace PatternsExamples.AbstractFactory.MacOs
{
    internal class MacOsButton : IButton
    {
        public OperationTypes Type => OperationTypes.MacOs;
    }
}