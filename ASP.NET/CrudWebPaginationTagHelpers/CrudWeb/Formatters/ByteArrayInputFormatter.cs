using Microsoft.AspNetCore.Mvc.Formatters;
using Microsoft.Net.Http.Headers;

namespace CrudWeb.Formatters;

public class ByteArrayInputFormatter : InputFormatter
{
    public ByteArrayInputFormatter()
    {
        SupportedMediaTypes.Add(MediaTypeHeaderValue.Parse("application/octet-stream"));
    }
    public override async Task<InputFormatterResult> ReadRequestBodyAsync(InputFormatterContext context)
    {
        var stream = new MemoryStream();
        await context.HttpContext.Request.Body.CopyToAsync(stream);
        return await InputFormatterResult.SuccessAsync(stream.ToArray());
    }
}