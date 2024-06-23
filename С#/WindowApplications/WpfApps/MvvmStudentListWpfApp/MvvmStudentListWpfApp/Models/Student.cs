using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MvvmStudentListWpfApp.Models;

public class Student : INotifyPropertyChanged, ICloneable
{
    private int _id;
    private string _name;
    private string _surname;
    private string _groupName;

    public Student() : this(0, "", "", "")
    {
    }

    public Student(int id, string name, string surname, string groupName)
    {
        _id = id;
        _name = name;
        _surname = surname;
        _groupName = groupName;
    }

    public int Id
    {
        get => _id;
        set
        {
            _id = value;
            OnPropertyChanged();
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            _name = value;
            OnPropertyChanged();
        }
    }

    public string Surname
    {
        get => _surname;
        set
        {
            _surname = value;
            OnPropertyChanged();
        }
    }

    public string GroupName
    {
        get => _groupName;
        set
        {
            _groupName = value;
            OnPropertyChanged();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    public object Clone() => new Student(_id, _name, _surname, _groupName);
}