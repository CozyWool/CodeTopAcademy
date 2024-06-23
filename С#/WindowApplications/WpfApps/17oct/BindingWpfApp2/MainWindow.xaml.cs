using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BindingWpfApp2;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>


public class DataSource
{
    public IEnumerable<string> DayOfWeekValues { get; set; }
}
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = CreateDayOfWeeks();
        var grid = (Grid)Content;
        grid.DataContext = new DataSource { DayOfWeekValues = CreateDayOfWeeks() };
    }

    private IEnumerable<string> CreateDayOfWeeks()
    {
        var days = new List<string>();
        foreach (DayOfWeek day in Enum.GetValues(typeof(DayOfWeek)))
        {
            days.Add(day.ToString());
        }
        return days;
    }
}
