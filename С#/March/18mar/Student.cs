namespace _18mar;

public class Student : IComparable<Student>, ICloneable
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int GroupNumber { get; set; }
    public Address Address { get; set; }

    public Student() : this(0, "", 0, new Address()) { }
    public Student(int Id, string Name, int GroupNumber, Address Address)
    {
        this.Id = Id;
        this.Name = Name;
        this.GroupNumber = GroupNumber;
        this.Address = (Address)Address.Clone();
    }
    public override string ToString()
    {
        return $"{Address.ToString() + " - " ?? ""}{Id} - {Name} - {GroupNumber}";
    }
    public int CompareTo(Student? other)
    {
        if (other == null) return 1;
        if (Id < other.Id) return -1;
        if (Id > other.Id) return 1;
        return 0;
    }

    public object Clone()
    {
        var student = new Student();
        student.Id = Id;
        student.Name = Name; 
        student.GroupNumber = GroupNumber;
        student.Address = (Address)(Address?.Clone() ?? new Address());
        return student;
    }
}

public class Address : ICloneable
{
    public string? City { get; set; }
    public string? Street { get; set; }

    public Address() : this(null, null) { }
    public Address(string? City, string? Street)
    {
        this.City = City;
        this.Street = Street;
    }
    public override string ToString() => $"{City ?? "Город не определен"}, {Street ?? "Улица не определена"}";

    public object Clone() => new Address(City, Street);
}



public class StudentAscComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        if (x == null) return -1;
        if (y == null) return 1;

        if (x.Id < y.Id) return -1;
        if (x.Id > y.Id) return 1;
        return 0;
    }
}
public class StudentDescComparer : IComparer<Student>
{
    public int Compare(Student? x, Student? y)
    {
        if (x == null) return 1;
        if (y == null) return -1;

        if (x.Id > y.Id) return -1;
        if (x.Id < y.Id) return 1;
        return 0;
    }
}
