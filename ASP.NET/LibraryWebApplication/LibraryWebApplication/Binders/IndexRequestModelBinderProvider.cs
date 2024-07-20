using LibraryWebApplication.Messages;
using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace LibraryWebApplication.Binders;

public class IndexRequestModelBinderProvider(IHttpContextAccessor httpContextAccessor)
    : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        var binder = new IndexRequestModelBinder(httpContextAccessor);
        return context.Metadata.ModelType == typeof(IndexRequest) ? binder : null;
    }
}