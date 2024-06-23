using System;

namespace BookLibraryWpfApp.ViewModel.Models;

public class Book
{
    private readonly string _name;
    private readonly string _author;
    private readonly DateTime _publishDate;

    public Book(string name, string author, DateTime publishDate)
    {
        _name = name;
        _author = author;
        _publishDate = publishDate;
    }

    public string Name => _name;
    public string Author => _author;
    public DateTime PublishDate => _publishDate;

    public override string ToString()
    {
        return $"{_name} by {_author} ({_publishDate:dd/MM/yyyy})";
    }
}