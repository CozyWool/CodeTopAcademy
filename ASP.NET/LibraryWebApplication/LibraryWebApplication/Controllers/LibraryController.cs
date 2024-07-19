using LibraryWebApplication.DataAccess.Filters;
using LibraryWebApplication.Messages;
using LibraryWebApplication.Models;
using LibraryWebApplication.Services;
using Microsoft.AspNetCore.Authorization;
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

    [AllowAnonymous]
    [Route("/")]
    [HttpGet("Index")]
    public async Task<IActionResult> Index([FromQuery] IndexRequest request)
    {
        var viewModel = await _bookService.GetSortedPaged(request.CurrentPage, request.PageSize, request.SortOrder);
        ViewBag.Title = "Библиотека";
        return View(viewModel);
    }

    [AllowAnonymous]
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

    [Authorize(Roles = "Admin, Manager")]
    [HttpGet("create")]
    public IActionResult Create()
    {
        var bookModel = new BookModel();

        ViewBag.Title = "Создание книги";
        return View("CreateBook", bookModel);
    }

    [Authorize(Roles = "Admin, Manager")]
    [HttpPost("create")]
    public IActionResult Create([FromForm] BookModel bookModel)
    {
        _bookService.Create(bookModel);
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Admin, Manager")]
    [HttpGet("edit/{id:int}")]
    public IActionResult Edit([FromRoute] int id)
    {
        var bookModel = _bookService.GetById(id);
        if (bookModel == null) return BadRequest();

        ViewBag.Title = $"Изменение {bookModel.Name}";
        return View("EditBook", bookModel);
    }

    [Authorize(Roles = "Admin, Manager")]
    [HttpPost("edit")]
    public IActionResult Edit([FromForm] BookModel bookModel)
    {
        _bookService.Update(bookModel);
        return RedirectToAction(nameof(Index));
    }

    [Authorize(Roles = "Admin, Manager")]
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

    public IActionResult UserData()
    {
        var list = User.Claims.Select(claim => claim.Value).ToList();
        ViewBag.Title = $"UserData";
        return Content(string.Join(" ", list));
    }
}