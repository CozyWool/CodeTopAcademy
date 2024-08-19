using System.Globalization;
using System.Text;
using System.Web;

namespace KeycloakExampleWebApi.Converters;

public static class DateToUriBase64Converter
{
    private const string Format = "ddd MMM dd yyyy HH:mm:ss.fffffff \"GMT\"zzz";
    private static readonly CultureInfo CultureInfo = new("en-US");

    public static string Encode(DateTimeOffset dt)
    {
        var dateAsString = dt.ToString(Format, CultureInfo);
        return EncodeString(dateAsString);
    }

    public static DateTimeOffset Decode(string encodedString)
    {
        var decodedString = DecodeString(encodedString);
        return DateTimeOffset.ParseExact(decodedString, new[] { Format }, CultureInfo);
    }

    private static string EncodeString(string dateAsString)
    {
        var bytes = Encoding.UTF8.GetBytes(dateAsString);
        var base64 = Convert.ToBase64String(bytes);
        return HttpUtility.UrlEncode(base64);
    }

    private static string DecodeString(string dateAsString)
    {
        var encodedString = HttpUtility.UrlDecode(dateAsString);
        var bytes = Convert.FromBase64String(encodedString);
        return Encoding.UTF8.GetString(bytes);
    }
}