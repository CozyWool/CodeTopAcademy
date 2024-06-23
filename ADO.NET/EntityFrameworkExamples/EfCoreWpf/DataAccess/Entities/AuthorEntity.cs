using System.Collections.Generic;

namespace EfCoreWpf.DataAccess.Entities;

//[Table("Author")]
public class AuthorEntity
{
    //[Key]
    public int Id { get; set; }
    
    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<BookEntity> Books { get; set; } = new List<BookEntity>();
}
