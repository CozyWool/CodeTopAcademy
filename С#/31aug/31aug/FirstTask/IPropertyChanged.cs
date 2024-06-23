using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _31aug.FirstTask
{
    public interface IPropertyChanged
    {
        event PropertyEventHandler PropertyChanged;
    }
}
