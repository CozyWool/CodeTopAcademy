using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Binding3WpfApp;
public class DataSource : INotifyPropertyChanged
{
    private int _value = 1;

    public int Value 
    { 
        get => _value; 
        set 
        {
            if (_value == value) return;

            _value = value;
            Notify();
        } 
    }
    public event PropertyChangedEventHandler? PropertyChanged;
    private void Notify([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
