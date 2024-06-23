using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpApp
{
    internal enum DayOfWeek : uint
    {
        Monday = 1,
        Tuesday, 
        Wednesday, 
        Thursday, 
        Friday, 
        Saturday,
        Sunday,
        AllDays = Monday|Tuesday|Wednesday|Thursday|Friday|Saturday|Sunday
    }
}
