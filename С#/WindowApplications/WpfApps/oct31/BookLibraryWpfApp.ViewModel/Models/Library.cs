using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;
using BookLibraryWpfApp.ViewModel.Commands;

namespace BookLibraryWpfApp.ViewModel.Models;

public class Library
{
    public List<Book> Books { get; } = new();

    public void AddBook(Book book)
    {
        Books.Add(book);
    }
}