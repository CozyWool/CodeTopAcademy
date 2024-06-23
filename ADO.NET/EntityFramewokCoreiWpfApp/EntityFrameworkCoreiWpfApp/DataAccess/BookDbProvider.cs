using System.Data;
using System.Windows.Documents;
using EntityFrameworkCoreiWpfApp.DataAccess.Entities;
using EntityFrameworkCoreiWpfApp.Models;
using Npgsql;

namespace EntityFrameworkCoreiWpfApp.DataAccess;

public class BookDbProvider : IDisposable
{
    private NpgsqlConnection? _connection;
    private readonly string _connectionString;

    public BookDbProvider(string connectionString)
    {
        _connectionString = connectionString;
        _connection = new NpgsqlConnection(connectionString);
    }

    public List<Author> GetAuthors()
    {
        var query = "SELECT * FROM public.\"Author\"";
        var list = new List<Author>();
        if (_connection.State != ConnectionState.Open) _connection.Open();
        var cmd = new NpgsqlCommand(query, _connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Author
            {
                Id = reader.GetInt32("Id"),
                FirstName = reader.GetString("FirstName"),
                LastName = reader.GetString("LastName")
            });
        }

        return list;
    }

    public List<Publisher> GetPublishers()
    {
        var query = "SELECT * FROM public.\"Publisher\"";
        var list = new List<Publisher>();
        if (_connection.State != ConnectionState.Open) _connection.Open();
        var cmd = new NpgsqlCommand(query, _connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new Publisher()
            {
                Id = reader.GetInt32("Id"),
                PublisherName = reader.GetString("PublisherName"),
                Address = reader.GetString("Address")
            });
        }

        return list;
    }

    public List<BookModel> GetBooks()
    {
        var list = new List<BookModel>();
        var query =
            "select \"Title\", a.\"FirstName\",a.\"LastName\", \"PageCount\", \"Price\", p.\"PublisherName\" from \"Book\" b\r\njoin \"Author\" a on b.\"AuthorId\" = a.\"Id\"\r\njoin \"Publisher\" p on b.\"PublisherId\" = p.\"Id\"";
        if (_connection.State != ConnectionState.Open) _connection.Open();
        var cmd = new NpgsqlCommand(query, _connection);
        using var reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            list.Add(new BookModel()
            {
                Title = reader.GetString("Title"),
                FirstName = reader.GetString("FirstName"),
                LastName = reader.GetString("LastName"),
                PageCount = reader.IsDBNull("PageCount") ? null : reader.GetInt32("PageCount"),
                Price = reader.IsDBNull("Price") ? null : reader.GetInt32("Price"),
                PublisherName = reader.GetString("Title")
            });
        }

        return list;
    }

    public void AddBook(Book book)
    {
        var query =
            "INSERT INTO public.\"Book\"(\"Title\", \"AuthorId\", \"PageCount\", \"Price\", \"PublisherId\") VALUES (@p1, @p2, @p3, @p4, @p5);";
        if (_connection.State != ConnectionState.Open) _connection.Open();
        var cmd = new NpgsqlCommand(query, _connection);
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