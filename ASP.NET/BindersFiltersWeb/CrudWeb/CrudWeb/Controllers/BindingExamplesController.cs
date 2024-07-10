using System.Text.Json;
using System.Web;
using CrudWeb.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudWeb.Controllers;

[Route("api/[controller]")]
public class BindingExamplesController : Controller
{
    public BindingExamplesController()
    {
    }

    [HttpGet("collections")]
    public IActionResult GetItems([FromQuery] string[] items)
    {
        const string str =
            "http://localhost:5246/api/BindingExamples/collections?items=%D0%A1%D1%82%D0%B0%D0%BD%D0%B8%D1%81%D0%BB%D0%B0%D0%B2&items=%D0%90%D0%BD%D0%B0%D1%81%D1%82%D0%B0%D1%81%D0%B8%D1%8F&items=%D0%92%D0%BB%D0%B0%D0%B4%D0%B8%D1%81%D0%BB%D0%B0%D0%B2&items=%D0%94%D0%B5%D0%BD%D0%B8%D1%81&items=%D0%94%D0%BC%D0%B8%D1%82%D1%80%D0%B8%D0%B9";
        var decodedUri = HttpUtility.UrlDecode(str);
        Console.WriteLine(decodedUri);
        Console.WriteLine(HttpUtility.UrlEncode(decodedUri));
        return Ok(items);
    }

    [HttpGet("object-collections")]
    public IActionResult GetItems([FromQuery] CategoryModel[] models)
    {
        const string str =
            "http://localhost:5246/api/BindingExamples/object-collections?models[0].id=1&models[0].name=phone&models[1].id=2&models[1].name=laptop&models[2].id=3&models[2].name=pc";
        return Ok(JsonSerializer.Serialize(models));
    }

    [HttpGet("product/create")]
    public IActionResult CreateProduct([FromQuery] ProductModel productModel)
    {
        
        if (!ModelState.IsValid)
        {
            return BadRequest();
        }
        return Ok(JsonSerializer.Serialize(productModel));
    }
}