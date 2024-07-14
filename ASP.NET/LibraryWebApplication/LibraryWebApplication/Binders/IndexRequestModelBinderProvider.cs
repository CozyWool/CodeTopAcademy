using LibraryWebApplication.Messages;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace LibraryWebApplication.Binders;

public class IndexRequestModelBinderProvider(ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor)
    : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        var binder = new IndexRequestModelBinder(httpContextAccessor);
        return context.Metadata.ModelType == typeof(IndexRequest) ? binder : null;
    }
}