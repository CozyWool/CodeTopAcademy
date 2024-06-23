using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;

namespace ValidationRuleFive;

public class Person : INotifyPropertyChanged
{
    private string? _name;
    private int _age;
    private string? _position;

    [Required(ErrorMessage = "Поле Name обязательно")]
    [StringLength(100, MinimumLength = 3, ErrorMessage = "Поле Name должно содержать минимум 3 символа")]
    public string? Name
    {
        get => _name;
        set
        {
            ValidateProperty(value);
            _name = value;
            OnPropertyChanged();
        }
    }
    
    [Range(0, 100, ErrorMessage = "Поле {0} должно быть в диапазоне от {1} до {2}")]
    public int Age
    {
        get => _age;
        set
        {
            ValidateProperty(value);
            _age = value;
            OnPropertyChanged();
        }
    }

    public string? Position
    {
        get => _position;
        set
        {
            ValidateProperty(value);
            _position = value;        
            OnPropertyChanged();
        }
    }

    public Person(string? position, int age, string? name)
    {
        Position = position;
        Age = age;
        Name = name;
    }

    public Person() : this(null, 0, null)
    {
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    // [NotifyPropertyChangedInvocator]
    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void ValidateProperty<T>(T value, [CallerMemberName]string? name = null)
    {
        Validator.ValidateProperty(value, new ValidationContext(this, null, null) {MemberName = name});
    }
}