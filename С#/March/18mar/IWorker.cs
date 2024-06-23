using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _18mar
{
    public interface IWorker
    {
        event EventHandler<string> WorkEnd;
        string Name { get; set; }
        bool IsWorking();
        void DoWork(string workName);
        void EndWork();
    }
}
