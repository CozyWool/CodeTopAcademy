using System.Data;
using Npgsql;
using ObjectModelWpf.DataAccess.Entities;
using ObjectModelWpf.Models;
using ObjectModelWpf.SqlQueries;

namespace ObjectModelWpf.DataAccess.Contexts;

public class BookDbProvider : IDisposable
{
    private readonly NpgsqlConnection _connection;

    public BookDbProvider(string connectionString)
    {
        _connection = new NpgsqlConnection(connectionString);
    }

    public Author[] GetAuthors()
    {
        var authors = new List<Author>();
        if (_connection.State != ConnectionState.Open) _connection.Open();
        var cmd = new NpgsqlCommand(Queries.GetAuthors, _connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            authors.Add(new Author
            {
                Id = reader.GetInt32("Id"),
                FirstName = reader.GetString("FirstName"),
                LastName = reader.GetString("LastName")
            });
        }

        return authors.ToArray();
    }

    public Publisher[] GetPublishers()
    {
        var publishers = new List<Publisher>();
        if (_connection.State != ConnectionState.Open) _connection.Open();
        var cmd = new NpgsqlCommand(Queries.GetPublishers, _connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            publishers.Add(new Publisher
            {
                Id = reader.GetInt32("Id"),
                Address = reader.GetString("Address"),
                PublisherName = reader.GetString("PublisherName")
            });
        }

        return publishers.ToArray();
    }

    public BookModel[] GetBooks()
    {
        var books = new List<BookModel>();
        if (_connection.State != ConnectionState.Open) _connection.Open();
        var cmd = new NpgsqlCommand(Queries.GetBooks, _connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            books.Add(new BookModel
            {
                Title = reader.GetString("Title"),
                FirstName = reader.GetString("FirstName"),
                PageCount = reader.IsDBNull("PageCount") ? null : reader.GetInt32("PageCount"),
                Price = reader.IsDBNull("Price") ? null : reader.GetInt32("Price"),
                PublisherName = reader.GetString("PublisherName")
            });
        }

        return books.ToArray();
    }

    public void AddBook(Book book)
    {
        if (_connection.State != ConnectionState.Open) _connection.Open();
        var cmd = new NpgsqlCommand(Queries.CreateBook, _connection);
        cmd.Parameters.Add(new NpgsqlParameter<string>("@p1", book.Title));
        cmd.Parameters.Add(new NpgsqlParameter<int>("@p2", book.AuthorId));
        cmd.Parameters.Add(new NpgsqlParameter<int?>("@p3", book.PageCount));
        cmd.Parameters.Add(new NpgsqlParameter<int?>("@p4", book.Price));
        cmd.Parameters.Add(new NpgsqlParameter<int>("@p5", book.PublisherId));
        cmd.ExecuteNonQuery();
    }

    public void Dispose()
    {
        _connection?.Close();
    }
}