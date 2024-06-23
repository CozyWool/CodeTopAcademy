using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using BookLibraryWpfApp.ViewModel.Models;

namespace BookLibraryWpfApp.ViewModel.ViewModels;

public class ListBookViewModel : INotifyPropertyChanged
{
    private readonly ObservableCollection<Book> _books;

    public ListBookViewModel(Library library)
    {
        _books = new ObservableCollection<Book>(library.Books);
    }
    
    public IReadOnlyCollection<Book> Books => _books;
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}