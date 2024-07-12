using LibraryWebApplication.Enums;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApplication.Messages;

public class IndexRequest
{
    [BindProperty(Name = "sortOrder")] public SortState? SortOrder { get; set; } = null;
    [BindProperty(Name = "page")] public int? CurrentPage { get; set; } = null;
    [BindProperty(Name = "pageSize")] public int? PageSize { get; set; } = null;
}