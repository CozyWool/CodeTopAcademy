using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpressionParser
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var expression = "1+2-3+3+6+4*5";
            Parser p = new Parser();
            var result = p.Parse(expression);
            Console.WriteLine(result);
            Console.ReadLine();
        }
    }
}
