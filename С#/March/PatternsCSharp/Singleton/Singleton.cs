using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace PatternsCSharp.Singleton
{
    public class Singleton
    {
        private static Singleton instance;
        private string _name;
        
        private Singleton() { }

        public static Singleton GetInstance()
        {
            instance ??= new Singleton();
            return instance;
        }

        public void SetValue(string value)
        { 
            _name = value;
        }
        public string GetValue()
        {
            return _name;
        }
    }
}
