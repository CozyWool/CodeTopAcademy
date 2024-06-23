using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BookLibraryWpfApp.Simplistics2.Commands;

namespace BookLibraryWpfApp.Simplistics2;

public class Library : INotifyPropertyChanged
{
    private readonly ObservableCollection<Book> _books = new ObservableCollection<Book>();
    private readonly Command _nextCommand;
    private readonly Command _preiviousCommand;

    private int _currentBookIndex = -1;
    private Book _currentBook;


    public Library()
    {
        _nextCommand = new DelegateCommand(_ => LoadNext(), _ => CanLoadNext());
        _preiviousCommand = new DelegateCommand(_ => LoadPrevious(), _ => CanLoadPrevious());

        _books.CollectionChanged += (_, _) => UpdatePreviousNextState();
        PropertyChanged += (_, e) =>
        {
            if (e.PropertyName.Equals(nameof(CurrentBook)))
            {
                UpdatePreviousNextState();
            }
        };
    }

    public IReadOnlyCollection<Book> Books => _books;

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

    public void AddBook(Book book)
    {
        _books.Add(book);

        if (_currentBookIndex == -1)
        {
            LoadBook(0);
        }
    }

    private void LoadBook(int index)
    {
        _currentBookIndex = index;
        CurrentBook = _books[_currentBookIndex];
    }

    private bool CanLoadNext() => _currentBookIndex < _books.Count - 1;

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

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}