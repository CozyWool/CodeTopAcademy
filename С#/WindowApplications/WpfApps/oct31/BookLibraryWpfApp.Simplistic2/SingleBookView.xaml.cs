using System.Linq;
using System.Windows;

namespace BookLibraryWpfApp.Simplistics2;

public partial class SingleBookView : Window
{
    private int _currentBookIndex = -1;

    public SingleBookView(Library library)
    {
        InitializeComponent();
        DataContext = library;
    }
}