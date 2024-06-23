using PatternsExamples.AbstractFactory.Enums;

namespace PatternsExamples.AbstractFactory.Abstractions
{
    internal interface IButton
    {
        OperationTypes Type { get; }
    }
}