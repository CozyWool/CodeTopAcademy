using System.Windows;

namespace BookLibraryWpfApp;

public partial class ListBookView : View
{
    public ListBookView(Library library) : base(library)
    {
        InitializeComponent();
    }

    private void ListBookView_OnLoaded(object sender, RoutedEventArgs e)
    {
        LoadBooks();
    }

    public override void Update()
    {
        LoadBooks();
    }

    private void LoadBooks()
    {
        Books.Items.Clear();
        foreach (var book in Library.Books)
        {
            Books.Items.Add(book);
        }
    }
}