namespace MiddlewareWeb.Configurations;

public class StudentsOptions
{
    public const string Key = "StudentsOptions";
    public string GroupName { get; set; }
    public List<string> Students { get; set; }
}