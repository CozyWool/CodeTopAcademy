using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace CrudWeb.Binders;

public class CustomDateTimeModelBinderProvider : IModelBinderProvider
{
    private readonly ILoggerFactory _loggerFactory;

    public CustomDateTimeModelBinderProvider(ILoggerFactory loggerFactory)
    {
        _loggerFactory = loggerFactory;
    }

    public IModelBinder GetBinder(ModelBinderProviderContext context)
    {
        var simpleTypeModelBinder = new SimpleTypeModelBinder(typeof(DateTime), _loggerFactory);
        var binder = new CustomDateTimeModelBinder(simpleTypeModelBinder);
        return context.Metadata.ModelType == typeof(DateTime) ? binder : null;
    }
}