using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace WrapperLib
{
    public class SimpleLibraryWrapper
    {
        [DllImport("SimpleLibraryC++.dll")]
        public static extern int add(int a, int b);
        [DllImport("SimpleLibraryC++.dll", EntryPoint = "fib")]
        //_declspec(dllexport) int _stdcall fib(int number)
        public static extern int Fibonachi(int number);

    }
}
