using System.Collections.Generic;

namespace BookLibraryWpfApp;

public class Library
{
    private readonly List<Book> _books = new List<Book>();
    private readonly List<View> _views = new List<View>();

    public IReadOnlyCollection<Book> Books => _books;

    public void AddBook(Book book)
    {
        _books.Add(book);
        NotifyViews();
    }

    public void AddView(View view)
    {
        _views.Add(view);   
    }

    private void NotifyViews()
    {
        foreach (var view in _views)
        {
            view.Update();
        }
    }
}