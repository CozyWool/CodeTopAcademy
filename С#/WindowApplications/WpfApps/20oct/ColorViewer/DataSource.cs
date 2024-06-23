using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace ColorViewer;
public class DataSource : INotifyPropertyChanged
{
    private byte alpha;
    private byte red;
    private byte green;
    private byte blue;

    public SolidColorBrush SelectedColor { get; set; } = new(Color.FromArgb(0, 0, 0, 0));
    public byte Alpha
    {
        get => alpha; set
        {
            if (alpha == value) return;

            alpha = value;
            Notify();
        }
    }
    public byte Red
    {
        get => red; set
        {
            if (red == value) return;

            red = value;
            Notify();
        }
    }
    public byte Green
    {
        get => green; set
        {
            if (green == value) return;

            green = value;
            Notify();
        }
    }
    public byte Blue
    {
        get => blue; set
        {
            if (blue == value) return;

            blue = value;
            Notify();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void Notify([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
