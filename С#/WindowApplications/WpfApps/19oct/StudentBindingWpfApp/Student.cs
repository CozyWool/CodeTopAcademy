using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentBindingWpfApp;

public class Student : INotifyPropertyChanged
{
    private int _id;
    private string _name;
    private string _surname;
    private DateTime _dateBirth;

    public int Id
    {
        get => _id;
        set
        {
            if (_id == value) return;

            _id = value;
            Notify();
        }
    }

    public string Name
    {
        get => _name;
        set
        {
            if (_name == value) return;

            _name = value;
            Notify();
        }
    }
    public string Surname
    {
        get => _surname;
        set
        {
            if (_surname == value) return;

            _surname = value;
            Notify();
        }
    }
    public DateTime DateBirth
    {
        get => _dateBirth;
        set
        {
            if (_dateBirth == value) return;
            _dateBirth = value;
            Notify();
        }
    }

    public override string ToString()
    {
        return $"{Id}, {Name}, {Surname}, {DateBirth}";
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void Notify([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
