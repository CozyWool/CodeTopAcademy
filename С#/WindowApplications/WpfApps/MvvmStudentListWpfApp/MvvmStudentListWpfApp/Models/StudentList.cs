using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;

namespace MvvmStudentListWpfApp.Models;

public class StudentList : INotifyCollectionChanged
{
    private readonly ObservableCollection<Student> _students = new();

    public IReadOnlyCollection<Student> Students => _students;

    public void AddStudent(Student student)
    {
        _students.Add(student);
        OnCollectionChanged(NotifyCollectionChangedAction.Add, new[] {student});
    }

    public void AddStudent(object obj)
    {
        AddStudent((Student) obj);
    }

    public void RemoveStudent(Student student)
    {
        _students.Remove(student);
        OnCollectionChanged(NotifyCollectionChangedAction.Remove, new[] {student});
    }

    public void RemoveStudent(object obj)
    {
        RemoveStudent(obj as Student ?? new Student());
    }

    public int IndexOf(Student student) => _students.IndexOf(student);

    public event NotifyCollectionChangedEventHandler? CollectionChanged;

    private void OnCollectionChanged(NotifyCollectionChangedAction action, IList changedItems)
    {
        CollectionChanged?.Invoke(this, new NotifyCollectionChangedEventArgs(action, changedItems));
    }

    public void EditStudent(Student oldStudent, Student newStudent)
    {
        _students[_students.IndexOf(oldStudent)] = newStudent;
    }
}