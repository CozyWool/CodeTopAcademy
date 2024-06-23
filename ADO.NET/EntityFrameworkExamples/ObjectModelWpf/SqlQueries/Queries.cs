namespace ObjectModelWpf.SqlQueries;

public static class Queries
{
    public const string GetAuthors = "SELECT \"Id\", \"FirstName\", \"LastName\" FROM public.\"Author\";";
    public const string GetPublishers = "SELECT \"Id\", \"PublisherName\", \"Address\" FROM public.\"Publisher\";";

    public const string GetBooks =
        "select \"Title\", a.\"FirstName\", \"PageCount\", \"Price\", p.\"PublisherName\" from \"Book\" b\r\njoin \"Author\" a on b.\"AuthorId\" = a.\"Id\"\r\njoin \"Publisher\" p on b.\"PublisherId\" = p.\"Id\"";

    public const string CreateBook =
        "INSERT INTO public.\"Book\"(\"Title\", \"AuthorId\", \"PageCount\", \"Price\", \"PublisherId\") VALUES (@p1, @p2, @p3, @p4, @p5);";
}