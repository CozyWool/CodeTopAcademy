using System.ComponentModel;

namespace ValidationRuleTwo;

public class Person : IDataErrorInfo
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

    public string Error { get; }

    public string this[string columnName]
    {
        get
        {
            var error = string.Empty;
            switch (columnName)
            {
                case nameof(Name):
                    break;
                case nameof(Age):
                    if(Age is > 100 or < 0)
                    {
                        error = "Возраст должен быть больше 0 и меньше 100";
                    }
                    break;
                case nameof(Position):
                    break;
                
            }
            return error;
        }
    }
}