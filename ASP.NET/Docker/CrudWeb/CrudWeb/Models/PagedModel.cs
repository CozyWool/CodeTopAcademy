namespace CrudWeb.Models;

public class PagedModel<T> where T : class
{
    public int CurrentPage { get; set; } = 1;
    public int Count { get; set; }
    public int PageSize { get; set; } = 10;
    public List<T> Items { get; set; }
    public int TotalPages => (int) Math.Ceiling(decimal.Divide(Count, PageSize));
}