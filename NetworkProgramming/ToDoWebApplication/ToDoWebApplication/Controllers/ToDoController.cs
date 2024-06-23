using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class ToDoController : ControllerBase
{
    // http - 80/8080
    // https - 443
    // http://localhost<port>/todo
    [HttpGet]
    public Task<List<string>> GetTasks()
    {
        return Task.FromResult(new List<string>
        {
            "Задача 1",
            "Задача 2",
            "Задача 3"
        });
    }

    [HttpGet("{id}")] // http://localhost<port>/todo/id
    // [HttpGet("id")] // http://localhost<port>/todo?id=1
    public Task<string> GetById(int id)
    {
        return Task.FromResult($"Задача {id}");
    }
}