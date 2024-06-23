using Patterns.AbstractFactory;
using Patterns.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.WinOS
{
    public class WinOSFactory : AbstractUIFactory
    {
        public override AbstractButton CreateButton()
        {
            return new WinOSButton();
        }

        public override AbstractTextBox CreateTextBox()
        {
            return new WinOSTextBox();
        }

        public override AbstractWindow CreateWindow()
        {
            return new WinOSWindow();
        }
    }
}
