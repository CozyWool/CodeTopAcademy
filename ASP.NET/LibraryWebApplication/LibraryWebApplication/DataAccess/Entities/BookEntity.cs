namespace LibraryWebApplication.DataAccess.Entities;

public class BookEntity
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Author { get; set; }
    public string Style { get; set; }
    public string Publisher { get; set; }
    public DateTime PublishingDate { get; set; }
}