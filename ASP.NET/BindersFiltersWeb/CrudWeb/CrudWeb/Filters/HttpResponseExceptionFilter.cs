using CrudWeb.Exceptions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace CrudWeb.Filters;

public class HttpResponseExceptionFilter : IExceptionFilter, IOrderedFilter
{
    public int Order => int.MaxValue - 10;
    
    public void OnException(ExceptionContext context)
    {
        if (context.Exception is not HttpResponseException exception) return;
        
        var objectResult = new ObjectResult(exception.Value)
        {
            StatusCode = (int) exception.Code
        };
        context.Result = objectResult;
        context.ExceptionHandled = true;
    }
}