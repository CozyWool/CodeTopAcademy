using Patterns.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Patterns.AbstractFactory
{
    public abstract class AbstractUIFactory
    {
        public abstract AbstractWindow CreateWindow();
        public abstract AbstractButton CreateButton();
        public abstract AbstractTextBox CreateTextBox();
    }
}
