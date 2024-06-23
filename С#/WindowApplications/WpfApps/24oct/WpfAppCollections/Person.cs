using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace WpfAppCollections;
public class Person : INotifyPropertyChanged
{
    private string? _name;

    public string? Name
    {
        get { return _name; }
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    public Person(string? name, int age)
    {
        _name = name;
        _age = age;
    }

    private int _age;

    public int Age
    {
        get { return _age; }
        set
        {
            _age = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
