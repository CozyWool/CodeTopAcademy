using PatternsExamples.AbstractFactory.Abstractions;
using PatternsExamples.AbstractFactory.Enums;

namespace PatternsExamples.AbstractFactory.Mobile
{
    internal class MobileTextBox : ITextBox
    {
        public OperationTypes Type => OperationTypes.Mobile;
    }
}