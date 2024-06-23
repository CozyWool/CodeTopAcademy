using DemoWebApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoWebApp.Controllers;

[Route("students")]
public class StudentController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet("{id}")]
    public IActionResult GetById([FromRoute] int id)
    {
        // return View("Student", id);
        return View("Student", new StudentModel(id, "Петя"));
    }
}