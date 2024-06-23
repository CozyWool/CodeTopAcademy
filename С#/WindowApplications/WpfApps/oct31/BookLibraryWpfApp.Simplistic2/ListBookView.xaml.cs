using System.Windows;

namespace BookLibraryWpfApp.Simplistics2;

public partial class ListBookView : Window
{
    public ListBookView(Library library)
    {
        InitializeComponent();
        DataContext = library;
    }
}
 