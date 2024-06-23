using System.Linq;
using System.Windows;

namespace BookLibraryWpfApp;

public partial class SingleBookView : View
{
    private int _currentBookIndex = -1;

    public SingleBookView(Library library) : base(library)
    {
        InitializeComponent();
    }

    public override void Update()
    {
        UpdateNavigation();
    }

    private void SingleBookView_OnLoaded(object sender, RoutedEventArgs e)
    {
        if (Library.Books.Count > 0)
        {
            LoadBook(0);
        }

        UpdateNavigation();
    }

    private void PreviousButton_OnClick(object sender, RoutedEventArgs e)
    {
        LoadBook(_currentBookIndex - 1);
    }

    private void NextButton_OnClick(object sender, RoutedEventArgs e)
    {
        LoadBook(_currentBookIndex + 1);
    }

    private void LoadBook(int bookIndex)
    {
        if (_currentBookIndex == bookIndex) return;
        var book = Library.Books.ElementAt(bookIndex);

        NameTextBlock.Text = book.Name;
        AuthorTextBlock.Text = book.Author;
        PublishDateTextBlock.Text = book.PublishDate.ToString("dd/MM/yyyy");

        _currentBookIndex = bookIndex;

        UpdateNavigation();
    }

    private void UpdateNavigation()
    {
        PreviousButton.IsEnabled = _currentBookIndex > 0 && Library.Books.Count > 0;
        NextButton.IsEnabled = _currentBookIndex < Library.Books.Count - 1 && Library.Books.Count > 0;
    }
}