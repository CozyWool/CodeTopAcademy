using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BookLibraryWpfApp.ViewModel.Commands;
using BookLibraryWpfApp.ViewModel.Models;

namespace BookLibraryWpfApp.ViewModel.ViewModels;

public class SingleBookViewModel : INotifyPropertyChanged
{
    private int _currentBookIndex = -1;
    private Book _currentBook;
    private readonly Library _library;
    
    private readonly Command _nextCommand;
    private readonly Command _preiviousCommand;

    public SingleBookViewModel(Library library)
    {
        _library = library;
        
        _nextCommand = new DelegateCommand(_ => LoadNext(), _ => CanLoadNext());
        _preiviousCommand = new DelegateCommand(_ => LoadPrevious(), _ => CanLoadPrevious());
        
        PropertyChanged += (_, e) =>
        {
            if (e.PropertyName.Equals(nameof(CurrentBook)))
            {
                UpdatePreviousNextState();
            }
        };

        if (_currentBookIndex == -1 && _library.Books.Count > 0)
        {
            LoadBook(0);
        }
    }
    
    public Book CurrentBook
    {
        get => _currentBook;
        set
        {
            if (!_currentBook?.Equals(value) ?? value != null)
            {
                _currentBook = value;
                OnPropertyChanged();
            }
        }
    }
    
    public ICommand NextCommand => _nextCommand;
    public ICommand PreviousCommand => _preiviousCommand;
    
    private void LoadBook(int index)
    {
        _currentBookIndex = index;
        CurrentBook = _library.Books[_currentBookIndex];
    }
    
    private bool CanLoadNext() => _currentBookIndex < _library.Books.Count - 1;
    
    private bool CanLoadPrevious() => _currentBookIndex > 0;
    
    private void LoadNext()
    {
        LoadBook(_currentBookIndex + 1);
    }
    
    private void LoadPrevious()
    {
        LoadBook(_currentBookIndex - 1);
    }
    
    private void UpdatePreviousNextState()
    {
        _nextCommand.RaiseCanExecuteChanged();
        _preiviousCommand.RaiseCanExecuteChanged();
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}