using System.Text.Json;
using CrudWeb.Messages;
using CrudWeb.Models;
using CrudWeb.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudWeb.Controllers;

[ApiExplorerSettings(IgnoreApi = true)]
[Route("home")]
public class HomeController : Controller
{
    private static List<EventModel> _events = new();
    private readonly CategoryModel[] _categories;
    private readonly IProductsService _productsService;

    public HomeController(IProductsService productsService)
    {
        _productsService = productsService;
        _categories = _productsService.GetCategories();
    }

    // [Route("/")]
    [HttpGet("Index")]
    public IActionResult Index()
    {
        return View(_productsService.GetAll());
    }

    // [Route("/")]
    [HttpGet("PagedIndex")]
    public IActionResult PagedIndex([FromQuery] PagedRequest request)
    {
        return View(_productsService.GetPagedProducts(request.CurrentPage, request.PageSize));
    }
    [Route("/")]
    [HttpGet("TagHelperPagedIndex")]
    public IActionResult TagHelperPagedIndex([FromQuery] PagedRequest request)
    {
        var currentPage = request.CurrentPage;
        var pageSize = request.PageSize;
        var pagedResult = _productsService.GetPagedProducts(currentPage, pageSize);
        var pagedViewModel = new PageViewModel<ProductModel>(pagedResult.Count, currentPage, pageSize)
        {
            Items = pagedResult.Items
        };
        
        return View(pagedViewModel);
    }

    [HttpGet("custom-binder")]
    public IActionResult CustomBinder()
    {
        return View(_events);
    }
    [HttpPost("custom-binder")]
    public IActionResult CustomBinder(EventModel ev)
    {
        ev.Id = Guid.NewGuid();
        _events.Add(ev);
        return Ok(JsonSerializer.Serialize(_events));
    }
    
    
    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var product = _productsService.GetById(id);
        return View("ProductDetails", product);
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        var productViewModel = new ProductViewModel
        {
            Categories = _categories
        };
        return View("CreateProduct", productViewModel);
    }

    [HttpPost("create")]
    public IActionResult Create([FromForm(Name = "Product")] ProductModel productModel)
    {
        _productsService.Create(productModel);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id}")]
    public IActionResult Edit([FromRoute] int id)
    {
        var productModel = _productsService.GetById(id);
        var productViewModel = new ProductViewModel
        {
            Product = productModel,
            Categories = _categories
        };
        return View("EditProduct", productViewModel);
    }

    [HttpPost("edit")]
    public IActionResult Edit([FromForm(Name = "Product")] ProductModel productModel)
    {
        _productsService.Update(productModel);
        return RedirectToAction(nameof(Index));
    }

    [HttpDelete("{id}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _productsService.Delete(id);
        return Ok();
    }
}