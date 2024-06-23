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

namespace DockPanelWpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        var button = new Button
        {
            Background = Brushes.Red,
            Content = "Ok",
            FontSize = 25,
            Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 0)),
            Height = 46,
            Width = 150
        };
        _grid.Children.Add(button);
        Grid.SetRow(button, 0);
        Grid.SetColumn(button, 0);

    }
}
