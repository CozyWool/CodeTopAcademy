using System.Configuration;
using System.Windows;

namespace EfCoreWpf
{
    /// <summary>
    /// Логика взаимодействия для BookWindow.xaml
    /// </summary>
    public partial class BookWindow : Window
    {
        /*private readonly BookDbProvider _bookDbProvider;
        private Author[] _authors;
        private Publisher[] _publishers;*/

        public BookWindow()
        {
            InitializeComponent();
            var connectionString = ConfigurationManager.ConnectionStrings["BooksConnectionString"].ConnectionString;
            //_bookDbProvider = new BookDbProvider(connectionString);
            InitCollections();
        }

        private void CreateButton_Click(object sender, RoutedEventArgs e)
        {
            /*var book = new Book
            {
                Title = BookName.Text,
                AuthorId = GetAuthorId(),
                PageCount = PageCount.Text.Length != 0 ? Convert.ToInt32(PageCount.Text) : null,
                Price = Price.Text.Length != 0 ? Convert.ToInt32(Price.Text) : null,
                PublisherId = GetPublisherId()
            };
            _bookDbProvider.AddBook(book);*/
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void InitCollections()
        {
            /*_authors = _bookDbProvider.GetAuthors();
            _publishers = _bookDbProvider.GetPublishers();
            Author.ItemsSource = _authors;
            Publisher.ItemsSource = _publishers;*/
        }

        /*private int GetAuthorId()
        {
            var a = (Author)Author.SelectedItem;
            return a.Id;
        }

        private int GetPublisherId()
        {
            var p = (Publisher)Publisher.SelectedItem;
            return p.Id;
        }*/
    }
}
