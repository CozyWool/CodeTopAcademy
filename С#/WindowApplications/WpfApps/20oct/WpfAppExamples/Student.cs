using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppExamples;
public class Student
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int GroupNumber { get; set; }

    public Student(int id, string name, int groupNumber)
    {
        Id = id;
        Name = name;
        GroupNumber = groupNumber;
    }

    public Student()
    {
    }

    public override string? ToString()
    {
        return $"{Id} {Name} {GroupNumber}";
    }
}
