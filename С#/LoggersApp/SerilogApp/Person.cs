internal class Person
{
    public int GroupNumber { get; set; }
    public string Name { get; set; }
    public string Surname { get; set; }

    public Person(int groupNumber, string name, string surname)
    {
        GroupNumber = groupNumber;
        Name = name;
        Surname = surname;
    }
    public override string? ToString()
    {
        return $"{GroupNumber}, {Name} {Surname}";
    }
}