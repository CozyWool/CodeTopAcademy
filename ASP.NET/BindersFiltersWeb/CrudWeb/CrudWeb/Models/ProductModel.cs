using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CrudWeb.Models;

public class ProductModel
{
    [BindNever] public int Id { get; set; }
    [BindRequired] public string Name { get; set; }
    public int Price { get; set; }
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
    public string ImageUri { get; set; }
}