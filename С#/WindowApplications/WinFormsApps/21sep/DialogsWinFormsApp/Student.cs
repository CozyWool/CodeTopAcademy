namespace DialogsWinFormsApp;

public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Group { get; set; }

    public Student(int id, string name, string group)
    {
        Id = id;
        Name = name;
        Group = group;
    }
}
