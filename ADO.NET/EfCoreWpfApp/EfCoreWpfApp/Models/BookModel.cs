﻿namespace EfCoreWpfApp.Models;

public class BookModel
{
    public string Title { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public int? PageCount { get; set; }
    public int? Price { get; set; }
    public string PublisherName { get; set; }

}