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

namespace ObservableCollectionWpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private DataSource dataSource = new DataSource();
    public MainWindow()
    {
        InitializeComponent();
        DataContext = dataSource;
    }

    private void AddNotifiableButton_Click(object sender, RoutedEventArgs e)
    {
        dataSource.AddValueToNotifiableCollection();
    }

    private void AddNonNotifiableButton_Click(object sender, RoutedEventArgs e)
    {

        dataSource.AddValueToNonNotifiableCollection();
    }
}
