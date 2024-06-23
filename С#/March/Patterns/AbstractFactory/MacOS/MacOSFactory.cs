using Patterns.AbstractFactory;
using Patterns.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.MacOS
{
    public class MacOSFactory : AbstractUIFactory
    {
        public override AbstractButton CreateButton()
        {
            return new MacOSButton();
        }

        public override AbstractTextBox CreateTextBox()
        {
            return new MacOSTextBox();
        }

        public override AbstractWindow CreateWindow()
        {
            return new MacOSWindow();
        }
    }
}
