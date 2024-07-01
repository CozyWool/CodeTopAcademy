namespace CrudWeb.Models;

public class ProductViewModel
{
    public ProductModel Product { get; set; }
    public CategoryModel[] Categories { get; set; }
}