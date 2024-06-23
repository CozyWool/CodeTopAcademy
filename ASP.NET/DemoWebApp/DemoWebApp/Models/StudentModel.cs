namespace DemoWebApp.Models;

public class StudentModel
{
    public StudentModel(int id, string name)
    {
        Id = id;
        Name = name;
    }

    public int Id { get; set; }    
    public string Name { get; set; }
}