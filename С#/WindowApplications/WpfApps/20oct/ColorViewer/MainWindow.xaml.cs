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

namespace ColorViewer;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private DataSource _dataSource;
    public MainWindow()
    {
        InitializeComponent();
        DataContext = _dataSource = CreateDataSource();
    }

    private DataSource CreateDataSource()
    {
        var dataSource = new DataSource();
        return dataSource;
    }

    private void AddButton_Click(object sender, RoutedEventArgs e)
    {

    }
}
