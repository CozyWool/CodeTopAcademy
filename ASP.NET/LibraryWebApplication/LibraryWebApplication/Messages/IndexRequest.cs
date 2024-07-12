using LibraryWebApplication.Enums;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApplication.Messages;

public class IndexRequest
{
    [BindProperty(Name = "sortOrder")] public SortState SortOrder { get; set; }
    [BindProperty(Name = "currentPage")] public int CurrentPage { get; set; }
    [BindProperty(Name = "pageSize")] public int PageSize { get; set; }
}