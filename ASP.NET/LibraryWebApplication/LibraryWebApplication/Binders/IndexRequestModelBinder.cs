using LibraryWebApplication.Enums;
using LibraryWebApplication.Messages;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibraryWebApplication.Binders;

public class IndexRequestModelBinder : IModelBinder
{
    private readonly IModelBinder _modelBinder;
    private readonly IHttpContextAccessor _httpContextAccessor;

    public IndexRequestModelBinder(IModelBinder modelBinder, IHttpContextAccessor httpContextAccessor)
    {
        _modelBinder = modelBinder;
        _httpContextAccessor = httpContextAccessor;
    }

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var context = _httpContextAccessor.HttpContext;
        var noCookies = !context.Request.Cookies.ContainsKey("pageSize") &&
                        !context.Request.Cookies.ContainsKey("currentPage") &&
                        !context.Request.Cookies.ContainsKey("sortOrder");
        if (noCookies)
        {
            return _modelBinder.BindModelAsync(bindingContext);
        }

        var request = new IndexRequest
        {
            PageSize = int.TryParse(bindingContext.ValueProvider.GetValue("pageSize").FirstValue, out var pageSize)
                ? pageSize
                : context.Request.Cookies.ContainsKey("pageSize")
                    ? Convert.ToInt32(context.Request.Cookies["pageSize"])
                    : 10,
            SortOrder = Enum.TryParse<SortState>(bindingContext.ValueProvider.GetValue("sortOrder").FirstValue,
                out var sortState)
                ? sortState
                : context.Request.Cookies.ContainsKey("sortOrder")
                    ? Enum.Parse<SortState>(context.Request.Cookies["sortOrder"])
                    : SortState.IdAsc
        };
        var b = bindingContext.ValueProvider.GetValue("currentPage").FirstValue;
        var a = int.TryParse(b,
            out var currentPage);
        request.CurrentPage = a
            ? currentPage
            : context.Request.Cookies.ContainsKey("currentPage")
                ? Convert.ToInt32(context.Request.Cookies["currentPage"])
                : 1;

        context.Response.Cookies.Append("pageSize", request.PageSize.ToString());
        context.Response.Cookies.Append("currentPage", request.CurrentPage.ToString());
        context.Response.Cookies.Append("sortOrder", request.SortOrder.ToString());

        bindingContext.Result = ModelBindingResult.Success(request);
        return Task.CompletedTask;
    }
}