namespace LibraryWebApplication.DataAccess.Filters;

//TODO: Стоит ли его выделять в отдельную папку? Или где его лучше хранить?
public class BookFilter
{
    public string? Name { get; set; }
    public string? Author { get; set; }
    public string? Style { get; set; }
    public string? Publisher { get; set; }
    public int? PublishingYear { get; set; }
}