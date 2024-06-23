using System.Windows;

namespace BookLibraryWpfApp;

public abstract class View : Window
{
    protected readonly Library Library;

    protected View(Library library)
    {
        Library = library;
        library.AddView(this);
    }
    
    public abstract void Update();
}