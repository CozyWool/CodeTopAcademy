using System.Collections;

namespace _18mar;

public class Auditory : IEnumerable<Student>
{
    private List<Student> _students = new();

    public void Add(Student student) 
    { 
        _students.Add(student);
    }
    public void Remove(Student student) 
    { 
        _students.Remove(student);
    }

    public IEnumerator<Student> GetEnumerator()
    {
        return new AuditoryEnumerator(_students);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return new AuditoryEnumerator(_students);
    }
}

public class AuditoryEnumerator : IEnumerator<Student>
{
    private int pos = -1;
    private readonly List<Student> students;

    public AuditoryEnumerator(List<Student> students)
    {
        this.students = students;
    }
    public Student Current => students[pos];

    object IEnumerator.Current => students[pos];

    public void Dispose() { }

    public bool MoveNext()
    {
        return ++pos < students.Count;
    }

    public void Reset()
    {
        pos = -1;
    }
}
