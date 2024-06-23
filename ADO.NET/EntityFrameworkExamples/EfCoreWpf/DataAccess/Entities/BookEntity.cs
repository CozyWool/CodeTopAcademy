namespace EfCoreWpf.DataAccess.Entities;

public class BookEntity
{
    public int Id { get; set; }

    public string Title { get; set; } = null!;

    public int AuthorId { get; set; }

    public int? PageCount { get; set; }

    public int? Price { get; set; }

    public int PublisherId { get; set; }
    public int Printing { get; set; }

    public virtual AuthorEntity AuthorEntity { get; set; } = null!;

    public virtual PublisherEntity PublisherEntity { get; set; } = null!;
}
