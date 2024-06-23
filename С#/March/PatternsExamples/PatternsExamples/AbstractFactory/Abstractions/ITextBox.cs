using PatternsExamples.AbstractFactory.Enums;

namespace PatternsExamples.AbstractFactory.Abstractions
{
    internal interface ITextBox
    {
        OperationTypes Type { get; }
    }
}