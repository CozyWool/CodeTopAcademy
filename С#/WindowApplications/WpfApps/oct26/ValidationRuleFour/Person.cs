namespace ValidationRuleFour;

public class Person
{
    public string? Name { get; set; }
    public int Age { get; set; }
    public string? Position { get; set; }

    public Person(string? position, int age, string? name)
    {
        Position = position;
        Age = age;
        Name = name;
    }

    public Person() : this(null, 0, null)
    {
    }
}