using CrudWebApp.DataAccess.Repositories;
using CrudWebApp.Models;
using CrudWebApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace CrudWebApp.Controllers;

public class HomeController : Controller
{
    private readonly IProductService _productService;

    public HomeController(IProductService productService)
    {
        _productService = productService;
    }

    public IActionResult Index()
    {
        return View(_productService.GetAll().OrderBy(x => x.Id).ToList());
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        return View("CreateProduct");
    }

    [HttpPost("create")]
    public IActionResult Create([FromForm] ProductModel productModel)
    {
        // productModel.Id = _productService.GetAll().Last().Id + 1;
        _productService.Create(productModel);
        return RedirectToAction(nameof(Index));
    }

    [HttpGet("edit/{id:int}")]
    public IActionResult Edit([FromRoute] int id)
    {
        var productModel = _productService.GetById(id);
        return View("EditProduct", productModel);
    }

    // [HttpPost("edit/{id:int}")]
    // public IActionResult Edit([FromForm] ProductModel productModel, [FromRoute] int id)
    [HttpPost("edit")]
    public IActionResult Edit([FromForm] ProductModel productModel)
    {
        // productModel.Id = id;
        _productService.Update(productModel);
        return RedirectToAction(nameof(Index));
    }


    [HttpDelete("{id:int}")]
    public IActionResult Delete([FromRoute] int id)
    {
        _productService.Delete(id);
        return Ok();
    }

    [HttpGet("{id:int}")]
    public IActionResult GetById([FromRoute] int id)
    {
        var productModel = _productService.GetById(id);
        return View("ProductDetails", productModel);
    }
}