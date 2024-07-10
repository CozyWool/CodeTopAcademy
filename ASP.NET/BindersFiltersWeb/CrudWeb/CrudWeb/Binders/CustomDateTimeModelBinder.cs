using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace CrudWeb.Binders;

public class CustomDateTimeModelBinder : IModelBinder
{
    private readonly IModelBinder _modelBinder;

    public CustomDateTimeModelBinder(IModelBinder modelBinder)
    {
        _modelBinder = modelBinder;
    }

    public Task BindModelAsync(ModelBindingContext bindingContext)
    {
        var datePartValues = bindingContext.ValueProvider.GetValue("Date");
        var timePartValues = bindingContext.ValueProvider.GetValue("Time");

        if (datePartValues == ValueProviderResult.None || timePartValues == ValueProviderResult.None)
        {
            return _modelBinder.BindModelAsync(bindingContext);
        }

        var date = datePartValues.FirstValue;
        var time = timePartValues.FirstValue;

        DateTime.TryParse(date, out var parsedDateValue);
        DateTime.TryParse(time, out var parsedTimeValue);

        var result = new DateTime(parsedDateValue.Year,
            parsedDateValue.Month,
            parsedDateValue.Day,
            parsedTimeValue.Hour,
            parsedTimeValue.Minute,
            parsedTimeValue.Second);
        bindingContext.Result = ModelBindingResult.Success(result);
        return Task.CompletedTask;
    }
}