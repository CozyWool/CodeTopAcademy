namespace EntityFrameworkCoreiWpfApp.DataAccess.Entities;

public class Book
{
    public int Id { get; set; }
    public string Title { get; set; }
    public int AuthorId { get; set; }
    public int? PageCount { get; set; }
    public int? Price { get; set; }
    public int PublisherId { get; set; }
}