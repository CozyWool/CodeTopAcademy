using System;
using System.Globalization;
using System.Windows.Data;

namespace ResourceWpfApp.Converters;

public class BoolToMessageConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is bool b)
        {
            return b ? "Данные персоны заполнены" : "Данные отсутствуют";
        }
        return "Invalid data";
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}