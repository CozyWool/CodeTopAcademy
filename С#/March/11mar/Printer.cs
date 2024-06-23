using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _11mar
{
    public class Printer : PrintBase, IPrint
    {
        public Printer()
        {
            PrinterType = "InterfaceConsole";
        }
        public string PrinterType { get; set; }

        public void Print()
        {
            Console.WriteLine(PrinterType);
        }
        public override void Print(string message)
        {
            Console.WriteLine(message);
        }

    }
}
