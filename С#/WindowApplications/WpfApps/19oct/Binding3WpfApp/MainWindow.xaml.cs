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
using System.Windows.Threading;

namespace Binding3WpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private DispatcherTimer timer;
    public MainWindow()
    {
        InitializeComponent();
        timer = new DispatcherTimer
        {
            Interval = TimeSpan.FromMilliseconds(1000),
        };
        timer.Tick += Timer_Tick;
        DataContext = new DataSource();
    }

    private void Timer_Tick(object? sender, EventArgs e)
    {
        var dataSource = (DataSource)DataContext;
        dataSource.Value++;
        UpdateTextBlock();
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (!timer.IsEnabled) timer.Start();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        UpdateTextBlock();
    }
    private void UpdateTextBlock()
    {
        var dataSource = (DataSource)DataContext;
        textBlock.Text = dataSource.Value.ToString();
    }
}
