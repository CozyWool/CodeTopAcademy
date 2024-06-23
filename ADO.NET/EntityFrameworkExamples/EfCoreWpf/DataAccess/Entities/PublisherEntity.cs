using System.Collections.Generic;

namespace EfCoreWpf.DataAccess.Entities;

public class PublisherEntity
{
    public int Id { get; set; }

    public string PublisherName { get; set; } = null!;

    public string Address { get; set; } = null!;

    public virtual ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();
}
