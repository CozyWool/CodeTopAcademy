using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace StudentCollectionWpfApp;

public class Student : INotifyPropertyChanged
{
    private int _id;
    private string _name;
    private int _groupNumber;

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
    public int GroupNumber
    {
        get => _groupNumber;
        set
        {
            if (_groupNumber == value) return;

            _groupNumber = value;
            Notify();
        }
    }

    public Student(int id, string name, int groupNumber)
    {
        Id = id;
        Name = name;
        GroupNumber = groupNumber;
    }

    public Student() : this(0, "", 0) { }

    public override string ToString()
    {
        return $"Id: {Id}, Name: {Name}, GroupNumber: {GroupNumber}";
    }

    public event PropertyChangedEventHandler? PropertyChanged;
    private void Notify([CallerMemberName] string propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}
