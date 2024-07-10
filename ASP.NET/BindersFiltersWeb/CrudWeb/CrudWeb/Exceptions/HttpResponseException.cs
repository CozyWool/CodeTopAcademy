using System.Net;

namespace CrudWeb.Exceptions;

public class HttpResponseException : Exception
{
    public HttpStatusCode Code { get; }
    public object Value { get; }

    public HttpResponseException(HttpStatusCode code, object value = null)
    {
        Code = code;
        Value = value;
    }
}