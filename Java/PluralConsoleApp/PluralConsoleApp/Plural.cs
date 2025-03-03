using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("PluralConsoleApp.Tests")]

namespace PluralConsoleApp;

internal static class Plural
{
    public static string PluralizeRubles(int count)
    {
        if (count % 100 is >= 10 and <= 20) return "рублей";
        if (count % 10 == 1) return "рубль";
        if (count % 10 is >= 2 and <= 4) return "рубля";
        return "рублей";
    }
}