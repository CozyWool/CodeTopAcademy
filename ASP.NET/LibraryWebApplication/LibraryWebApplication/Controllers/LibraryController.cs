using LibraryWebApplication.DataAccess.Filters;
using LibraryWebApplication.Enums;
using LibraryWebApplication.Messages;
using LibraryWebApplication.Models;
using LibraryWebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApplication.Controllers;

[Route("library")]
public class LibraryController : Controller
{
    private readonly IBookService _bookService;

    public LibraryController(IBookService bookService)
    {
        _bookService = bookService;
    }

    [Route("/")]
    [HttpGet("Index")]
    public async Task<IActionResult> Index([FromQuery] IndexRequest request)
    {
        //TODO: биндер наверное сделаю, после всего остального
        request.PageSize ??= HttpContext.Request.Cookies.ContainsKey("pageSize")
            ? Convert.ToInt32(HttpContext.Request.Cookies["pageSize"])
            : 10;
        request.CurrentPage ??= HttpContext.Request.Cookies.ContainsKey("currentPage")
            ? Convert.ToInt32(HttpContext.Request.Cookies["currentPage"])
            : 1;
        request.SortOrder ??= HttpContext.Request.Cookies.ContainsKey("sortOrder")
            ? Enum.Parse<SortState>(HttpContext.Request.Cookies["sortOrder"])
            : SortState.IdAsc;

        HttpContext.Response.Cookies.Append("pageSize", request.PageSize.ToString());
        HttpContext.Response.Cookies.Append("currentPage", request.CurrentPage.ToString());
        HttpContext.Response.Cookies.Append("sortOrder", request.SortOrder.ToString());

        var viewModel = await _bookService.GetSortedPaged(request.CurrentPage ?? 1, request.PageSize ?? 10,
            request.SortOrder ?? SortState.IdAsc);
        ViewBag.Title = "Библиотека";
        return View(viewModel);
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var bookModel = _bookService.GetById(id);
        if (bookModel == null)
            throw new ArgumentException();
        // return NotFound(id);

        ViewBag.Title = bookModel.Name;
        return View("DetailedBook", bookModel);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        var bookModel = new BookModel();

        ViewBag.Title = "Создание книги";
        return View("CreateBook", bookModel);
    }

    [HttpPost("create")]
    public IActionResult Create([FromForm] BookModel bookModel)
    {
        _bookService.Create(bookModel);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id:int}")]
    public IActionResult Edit([FromRoute] int id)
    {
        var bookModel = _bookService.GetById(id);
        if (bookModel == null) return BadRequest();

        ViewBag.Title = $"Изменение {bookModel.Name}";
        return View("EditBook", bookModel);
    }

    [HttpPost("edit")]
    public IActionResult Edit([FromForm] BookModel bookModel)
    {
        _bookService.Update(bookModel);
        return RedirectToAction(nameof(Index));
    }

    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _bookService.Delete(id);
        return Ok();
    }

    [HttpGet("filter")]
    public IActionResult FilterBooks([FromQuery] BookFilter bookFilter)
    {
        //TODO: Объединить с сортировкой и пагинацией

        var books = _bookService.GetBooksByFilter(bookFilter);
        var filteredBooksModel = new FilteredBooksModel
        {
            FilteredBooks = books
        };

        ViewBag.Title = "Поиск книг";
        return View("FilteredBooks", filteredBooksModel);
    }
}