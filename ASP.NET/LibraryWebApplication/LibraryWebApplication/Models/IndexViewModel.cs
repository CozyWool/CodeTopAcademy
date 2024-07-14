namespace LibraryWebApplication.Models;

public class IndexViewModel
{
    public SortViewModel SortViewModel { get; set; }
    public PagedModel<BookModel> PagedModel { get; set; }
}