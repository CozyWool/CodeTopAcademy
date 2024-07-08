namespace CrudWeb.Models;

public class PageViewModel<T> where T : class
{
    public int PageNumber { get; set; }
    public int PageSize { get; }
    public int TotalPages { get; set; }
    public bool HasPreviousPage => PageNumber > 1;
    public bool HasNextPage => PageNumber < TotalPages;
    public List<T> Items { get; set; }

    public PageViewModel(int count, int pageNumber, int pageSize)
    {
        PageNumber = pageNumber;
        PageSize = pageSize;
        TotalPages = (int) Math.Ceiling(decimal.Divide(count, pageSize));
    }
}