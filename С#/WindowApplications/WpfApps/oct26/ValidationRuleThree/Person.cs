using System;

namespace ValidationRuleThree;

public class Person
{
    private int _age;
    public string? Name { get; set; }

    public int Age
    {
        get => _age;
        set
        {
            if (value is <0 or >100)
            {
                throw new ArgumentException("Возраст должен быть больше 0 и меньше 100");
            }
            _age = value;
        }
    }

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