using Microsoft.AspNetCore.Mvc;
using ToDoListWebApi.Models;

namespace ToDoListWebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class TasksController : ControllerBase
{
    private static List<ToDoItem> items = [];

    public TasksController()
    {
        if (items.Count == 0)
        {
            items.AddRange(
            [
                new ToDoItem {Id = 1, Name = "Task 1", IsComplete = false},
                new ToDoItem {Id = 2, Name = "Task 2", IsComplete = false},
                new ToDoItem {Id = 3, Name = "Task 3", IsComplete = false},
                new ToDoItem {Id = 4, Name = "Task 4", IsComplete = false},
                new ToDoItem {Id = 5, Name = "Task 5", IsComplete = false},
            ]);
        }
    }

    [HttpGet]
    public async Task<ToDoItem[]> GetTasks()
    {
        await Task.Delay(TimeSpan.FromSeconds(0.5));
        return items.ToArray();
    }
    [HttpGet("{id:int}")]
    public async Task<ToDoItem?> GetTaskById(int id)
    {
        await Task.Delay(TimeSpan.FromSeconds(0.5));
        var existingItem = items.FirstOrDefault(toDoItem => toDoItem.Id == id);

        return existingItem;
    }

    [HttpPost]
    public Task Create(ToDoItem item)
    {
        items.Add(item);
        return Task.CompletedTask;
    }

    [HttpPut]
    public Task Update(ToDoItem item)
    {
        var existingItem = items.FirstOrDefault(toDoItem => toDoItem.Id == item.Id);

        if (existingItem == null) return Task.CompletedTask;

        existingItem.Id = item.Id;
        existingItem.Name = item.Name;
        existingItem.IsComplete = item.IsComplete;
        return Task.CompletedTask;
    }

    [HttpDelete]
    public Task Delete([FromBody] int id)
    {
        var existingItem = items.FirstOrDefault(toDoItem => toDoItem.Id == id);

        if (existingItem == null) return Task.CompletedTask;
        
        items.Remove(existingItem);
        return Task.CompletedTask;
    }
}