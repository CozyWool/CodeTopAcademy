﻿namespace ToDoListWebApi.Models;

public class ToDoItem
{
    public int Id { get; set; }
    public string Name { get; set; }
    public bool IsComplete { get; set; }
}