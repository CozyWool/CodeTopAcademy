using CrudWeb.Controllers;
using CrudWeb.Models;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CrudWeb.Filters;

public class HttpResponseActionFilter : IActionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 10;

    public void OnActionExecuted(ActionExecutedContext context)
    {
        if (context.Controller is not ProductsController controller) return;
        
        var actionName = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor).ActionName;
        if (actionName != nameof(controller.GetAll)) return;
        
        var products = ((Microsoft.AspNetCore.Mvc.ObjectResult)context.Result)?.Value as ProductModel[];
        if (products != null) context.HttpContext.Response.Headers.Append("products-count", products.Length.ToString());
    }

    public void OnActionExecuting(ActionExecutingContext context)
    {
    }
}