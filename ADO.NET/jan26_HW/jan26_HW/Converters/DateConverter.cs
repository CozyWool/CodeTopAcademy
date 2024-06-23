using System.Globalization;
using System.Windows.Data;

namespace jan26_HW.Converters;

public class DateConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateOnly d)
        {
            return d.ToDateTime(TimeOnly.MinValue);
        }

        throw new ArgumentException("Wrong data type");
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (value is DateTime d)
        {
            return DateOnly.FromDateTime(d);
        }

        throw new ArgumentException("Wrong data type");
    }
}