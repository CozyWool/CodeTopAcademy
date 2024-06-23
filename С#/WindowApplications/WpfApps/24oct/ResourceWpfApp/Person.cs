using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfAppCollections;

public class Person : INotifyPropertyChanged
{
    private string? _name;

    public string? Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(HasData));
        }
    }

    private string? _surname;

    public string? Surname
    {
        get => _surname;
        set
        {
            _surname = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(HasData));
        }
    }

    public bool HasData => !string.IsNullOrEmpty(Name) && !string.IsNullOrEmpty(Surname);
    public event PropertyChangedEventHandler? PropertyChanged;

    public Person(string? name, string? surname)
    {
        _name = name;
        _surname = surname;

    }

    public Person() : this("", "") {}

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
