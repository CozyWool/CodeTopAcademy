namespace LibraryWebApplication.Models;

public class PagedModel<T>(int count, int currentPage, int pageSize, List<T> items)
    where T : class
{
    public int CurrentPage { get; init; } = currentPage;
    public bool HasPreviousPage => CurrentPage > 1;
    public bool HasNextPage => CurrentPage < TotalPages;
    public int PageSize { get; init; } = pageSize;
    public List<T> Items { get; init; } = items;
    public int TotalPages { get; } = (int) Math.Ceiling(decimal.Divide(count, pageSize));

    public PagedModel(int count, int currentPage, int pageSize) : this(count, currentPage, pageSize, new List<T>())
    {
        
    }
}