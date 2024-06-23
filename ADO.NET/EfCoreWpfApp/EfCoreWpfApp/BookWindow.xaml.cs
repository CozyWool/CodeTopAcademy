using System.Configuration;
using System.Windows;

namespace EfCoreWpfApp;

public partial class BookWindow : Window
{
    // private readonly BookDbProvider _bookDbProvider;
    // private List<Author> _authors;
    // private List<Publisher> _publishers;

    public BookWindow()
    {
        InitializeComponent();
        var connectionString = ConfigurationManager.ConnectionStrings["BooksConnectionString"].ConnectionString;
        // _bookDbProvider = new BookDbProvider(connectionString);
        InitCollections();
    }

    private void InitCollections()
    {
        // _authors = _bookDbProvider.GetAuthors();
        // _publishers = _bookDbProvider.GetPublishers();
        // AuthorComboBox.ItemsSource = _authors;
        // PublisherComboBox.ItemsSource = _publishers;
    }

    private void OkButton_OnClick(object sender, RoutedEventArgs e)
    {
        // var book = new Book
        // {
        //     Title = NameTextBox.Text,
        //     AuthorId = GetAuthorId(),
        //     PageCount = PageCountTextBox.Text.Length != 0 ? Convert.ToInt32(PageCountTextBox.Text) : null,
        //     Price = PriceTextBox.Text.Length != 0 ? Convert.ToInt32(PriceTextBox.Text) : null,
        //     PublisherId = GetPublisherId()
        // };

        // _bookDbProvider.AddBook(book);
        DialogResult = true;
        Close();
    }

    // private int GetAuthorId()
    // {
    //     var author = (Author) AuthorComboBox.SelectedItem;
    //     return author.Id;
    // }
    //
    // private int GetPublisherId()
    // {
    //     var publisher = (Publisher) PublisherComboBox.SelectedItem;
    //     return publisher.Id;
    // }

    private void CancelButton_OnClick(object sender, RoutedEventArgs e)
    {
        Close();
    }
}