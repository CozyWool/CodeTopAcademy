namespace LibraryWebApplication.DataAccess.Filters;

public class BookFilter
{
    public string? Name { get; set; }
    public string? Author { get; set; }
    public string? Style { get; set; }
    public string? Publisher { get; set; }
    public int? PublishingYear { get; set; }
}