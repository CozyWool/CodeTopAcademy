using System.Configuration;
using System.Windows;
using ObjectModelWpf.DataAccess.Contexts;

namespace ObjectModelWpf;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
        LoadData();
    }

    private void AddBookButton_Click(object sender, RoutedEventArgs e)
    {
        var bookWindow = new BookWindow();
        bookWindow.ShowDialog();
    }

    private void LoadData()
    {
        var connectionString = ConfigurationManager.ConnectionStrings["BooksConnectionString"].ConnectionString;
        using var bookDbProvider = new BookDbProvider(connectionString);
        BooksDataGrid.ItemsSource = bookDbProvider.GetBooks();
    }
}