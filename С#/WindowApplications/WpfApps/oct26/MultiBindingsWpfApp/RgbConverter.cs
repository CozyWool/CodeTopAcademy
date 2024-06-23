using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;

namespace MultiBindingsWpfApp;

public class RgbConverter : IMultiValueConverter
{
    public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
    {
        var brush = new SolidColorBrush
        {
            Color = Color.FromRgb(
                System.Convert.ToByte(values[0]),
                System.Convert.ToByte(values[1]),
                System.Convert.ToByte(values[2]))
        };
        return brush;
    }

    public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}