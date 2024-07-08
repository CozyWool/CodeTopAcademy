using Microsoft.AspNetCore.Mvc;

namespace CrudWeb.Messages;

public class PagedRequest
{
    [BindProperty(Name = "page")] public int CurrentPage { get; set; } = 1;
    [BindProperty(Name = "pageSize")] public int PageSize { get; set; } = 10;
}