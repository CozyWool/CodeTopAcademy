using Patterns.AbstractFactory;
using Patterns.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.Mobile
{
    public class MobileFactory : AbstractUIFactory
    {
        public override AbstractButton CreateButton()
        {
            return new MobileButton();
        }

        public override AbstractTextBox CreateTextBox()
        {
            return new MobileTextBox();
        }

        public override AbstractWindow CreateWindow()
        {
            return new MobileWindow();
        }
    }
}
