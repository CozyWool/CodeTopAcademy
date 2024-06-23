using AutoMapper;
using LibraryWebApplication.DataAccess.Filters;
using LibraryWebApplication.DataAccess.Repositories;
using LibraryWebApplication.Models;
using LibraryWebApplication.Services;
using Microsoft.AspNetCore.Mvc;

namespace LibraryWebApplication.Controllers;

[Route("library")]
public class LibraryController : Controller
{
    private readonly IBookService _bookService;
    private readonly IMapper _mapper;

    public LibraryController(IBookService bookService, IMapper mapper)
    {
        _bookService = bookService;
        _mapper = mapper;
    }

    [Route("/")]
    [HttpGet("Index")]
    public IActionResult Index()
    {
        ViewBag.Title = "Библиотека";

        return View(_bookService.GetAll());
    }

    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var bookModel = _bookService.GetById(id);
        if (bookModel == null)
            return NotFound(id);

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
    public IActionResult FilterBooks(
        [FromQuery] string? name = null,
        [FromQuery] string? author = null,
        [FromQuery] string? style = null,
        [FromQuery] string? publisher = null,
        [FromQuery] int? publishingYear = null
    )
    {
        var bookFilter = new BookFilter
        {
            Name = name,
            Author = author,
            Style = style,
            Publisher = publisher,
            PublishingYear = publishingYear
        };
        var books = _bookService.GetBooksByFilter(bookFilter);
        var filteredBooksModel = new FilteredBooksModel
        {
            FilteredBooks = books
        };

        ViewBag.Title = "Поиск книг";
        return View("FilteredBooks", filteredBooksModel);
    }
}