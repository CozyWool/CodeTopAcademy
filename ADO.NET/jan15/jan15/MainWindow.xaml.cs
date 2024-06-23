using System;
using System.Collections.Generic;
using System.Data.Common;
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

namespace jan15;
public partial class MainWindow : Window
{
    private DbConnection connection;
    private DbProviderFactory factory;

    public MainWindow()
    {
        InitializeComponent();
        StartScript.IsEnabled = false;
    }

    private void StartScript_OnClick(object sender, RoutedEventArgs e)
    {

    }

    private void GetAllProviders_OnClick(object sender, RoutedEventArgs e)
    {
        
    }
}