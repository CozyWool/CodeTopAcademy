using System.Collections.Generic;
using PatternsExamples.AbstractFactory.Abstractions;
using PatternsExamples.AbstractFactory.Enums;
using PatternsExamples.Loggers;

namespace PatternsExamples.AbstractFactory.Mobile
{
    internal class MobileWindow : IWindow
    {
        private readonly ILogger _logger;
        private readonly List<IButton> _buttons = new List<IButton>();
        private readonly List<ITextBox> _textBox = new List<ITextBox>();

        public MobileWindow() : this(new ConsoleLogger())
        {
        }

        public MobileWindow(ILogger logger)
        {
            _logger = logger;
        }

        public int Width { get; set; }

        public int Height { get; set; }

        public OperationTypes Type => OperationTypes.Mobile;

        public void AddElement(IButton button)
        {
            if (Type != button.Type)
            {
                _logger.Log($"Incosistent types window ({Type}) and button ({button.Type})");
                return;
            }

            _buttons.Add(button);
            _logger.Log($"Added {button.Type} button");
        }

        public void AddElement(ITextBox textBox)
        {
            if (Type != textBox.Type)
            {
                _logger.Log($"Incosistent types window ({Type}) and textBox ({textBox.Type})");
                return;
            }

            _textBox.Add(textBox);
            _logger.Log($"Added {textBox.Type} textBox");
        }
    }
}