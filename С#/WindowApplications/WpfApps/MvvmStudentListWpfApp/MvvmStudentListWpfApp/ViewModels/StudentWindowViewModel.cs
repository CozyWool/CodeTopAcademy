using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using MvvmStudentListWpfApp.Commands;
using MvvmStudentListWpfApp.Models;

namespace MvvmStudentListWpfApp.ViewModels;

public class StudentWindowViewModel : INotifyPropertyChanged
{
    private bool CanOkClick() => !string.IsNullOrEmpty(StudentToEdit.Name) &&
                                 !string.IsNullOrEmpty(StudentToEdit.Surname) &&
                                 !string.IsNullOrEmpty(StudentToEdit.GroupName);

    public StudentWindowViewModel(Window owner, Student studentToEdit)
    {
        StudentToEdit = studentToEdit;
        Owner = owner;
        OkCommand = new DelegateCommand(OkClick, _ => CanOkClick());
        CancelCommand = new DelegateCommand(CancelClick);
    }

    public StudentWindowViewModel(Window owner) : this(owner, new Student())
    {
        Owner = owner;
        Owner.Title = "Add student";
    }

    public Student StudentToEdit { get; }
    public Command OkCommand { get; }
    public Command CancelCommand { get; }

    private void OkClick(object obj)
    {
        Owner.DialogResult = true;
        Owner.Close();
    }

    private void CancelClick(object obj)
    {
        Owner.DialogResult = false;
        Owner.Close();
    }

    public Window Owner { get; }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}