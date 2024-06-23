namespace EfCoreWpfApp.DataAccess;

public class Book
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int AuthorId { get; set; }

    public int? PageCount { get; set; }

    public int? Price { get; set; }

    public int PublisherId { get; set; }

    public virtual Author Author { get; set; } = null!;

    public virtual Publisher Publisher { get; set; } = null!;
}
