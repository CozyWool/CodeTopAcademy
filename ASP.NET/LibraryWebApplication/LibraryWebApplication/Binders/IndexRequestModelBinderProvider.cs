using LibraryWebApplication.Messages;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace LibraryWebApplication.Binders;

public class IndexRequestModelBinderProvider(ILoggerFactory loggerFactory, IHttpContextAccessor httpContextAccessor)
    : IModelBinderProvider
{
    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        var simpleTypeModelBinder = new SimpleTypeModelBinder(typeof(IndexRequest), loggerFactory);
        var binder = new IndexRequestModelBinder(simpleTypeModelBinder, httpContextAccessor);
        return context.Metadata.ModelType == typeof(IndexRequest) ? binder : null;
    }
}