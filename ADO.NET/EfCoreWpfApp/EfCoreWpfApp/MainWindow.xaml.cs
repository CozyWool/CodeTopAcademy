using System.Configuration;
using System.Windows;
using EfCoreWpfApp.DataAccess;
using EfCoreWpfApp.Models;
using Microsoft.EntityFrameworkCore;

namespace EfCoreWpfApp;

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
        var booksContext = new BooksContext();
        var items = booksContext.Books.Include(x => x.Author)
            .Include(x => x.Publisher)
            .Select(book => new BookModel
            {
                Title = book.Title,
                FirstName = book.Author.FirstName,
                LastName = book.Author.LastName,
                PageCount = book.PageCount,
                Price = book.Price,
                PublisherName = book.Publisher.PublisherName
            })
            .ToList();
        BooksDataGrid.ItemsSource = items;
    }

    private void AddBookButton_OnClick(object sender, RoutedEventArgs e)
    {
        var window = new BookWindow();
        window.ShowDialog();
    }
}