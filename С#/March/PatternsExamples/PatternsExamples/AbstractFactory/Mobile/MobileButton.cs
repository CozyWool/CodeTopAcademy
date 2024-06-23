using PatternsExamples.AbstractFactory.Abstractions;
using PatternsExamples.AbstractFactory.Enums;

namespace PatternsExamples.AbstractFactory.Mobile
{
    internal class MobileButton : IButton
    {
        public OperationTypes Type => OperationTypes.Mobile;
    }
}