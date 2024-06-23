namespace EfCoreWpfApp.DataAccess;

//[Table("Author", Schema = "test")]
public class Author
{
    //[PrimaryKey("Author_pkey")]
    public int Id { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public virtual ICollection<Book> Books { get; set; } = new List<Book>();
}