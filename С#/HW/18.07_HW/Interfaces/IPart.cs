using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using _18._07_HW.Enums;

namespace _18._07_HW.Interfaces
{
    public interface IPart
    {
        PartTypes Type { get; set; }
        bool IsBuilded { get; set; }
        IWorker? ResponseWorker { get; set; } // Ответственный за работу
        //public void Build(IWorker worker);
    }
}
