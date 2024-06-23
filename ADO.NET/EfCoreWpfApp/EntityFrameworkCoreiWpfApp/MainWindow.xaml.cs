using System.Configuration;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using EntityFrameworkCoreiWpfApp.DataAccess;

namespace EntityFrameworkCoreiWpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        LoadData();
    }

    private void LoadData()
    {
        var connectionString = ConfigurationManager.ConnectionStrings["BooksConnectionString"].ConnectionString;
        using var bookDbProvider = new BookDbProvider(connectionString);
        BooksDataGrid.ItemsSource = bookDbProvider.GetBooks();
    }

    private void AddBookButton_OnClick(object sender, RoutedEventArgs e)
    {
        var window = new BookWindow();
        if (window.ShowDialog() == true)
        {
            
        }
    }
}