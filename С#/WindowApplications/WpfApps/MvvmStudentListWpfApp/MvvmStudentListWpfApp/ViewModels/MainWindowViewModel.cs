using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using MvvmStudentListWpfApp.Commands;
using MvvmStudentListWpfApp.Models;
using MvvmStudentListWpfApp.Views;

namespace MvvmStudentListWpfApp.ViewModels;

public class MainWindowViewModel : INotifyPropertyChanged
{
    public MainWindowViewModel(StudentList students, Window owner)
    {
        Students = students;
        Owner = owner;
        AddStudentCommand = new DelegateCommand(_ => AddStudent());
        RemoveStudentCommand = new DelegateCommand(Students.RemoveStudent);
        EditStudentCommand = new DelegateCommand(EditStudent);
    }

    private void AddStudent()
    {
        var addWindow = new StudentWindow(Owner);
        var windowViewModel = new StudentWindowViewModel(addWindow);
        addWindow.DataContext = windowViewModel;
        
        if (addWindow.ShowDialog() != true) return;

        if (addWindow.DataContext is not StudentWindowViewModel viewModel)
            return;
        var student = viewModel.StudentToEdit;
        student.Id = Students.Students.Last().Id + 1;
        Students.AddStudent(student);
    }

    private void EditStudent(object obj)
    {
        if (obj is not Student student)
            return;
        
        var editWindow = new StudentWindow(Owner);
        var windowViewModel = new StudentWindowViewModel(editWindow, student.Clone() as Student);
        editWindow.DataContext = windowViewModel;

        if (editWindow.ShowDialog() != true) return;
        
        // На всякий случай оставил проверку
        if (editWindow.DataContext is not StudentWindowViewModel viewModel)
            return;
        Students.EditStudent(student, viewModel.StudentToEdit);
    }

    public Command AddStudentCommand { get; }
    public Command RemoveStudentCommand { get; }
    public Command EditStudentCommand { get; }
    public Window Owner { get; }

    public StudentList Students { get; }


    private void SetProperty<T>(ref T oldValue, T newValue, string propertyName)
    {
        if (!oldValue?.Equals(newValue) ?? newValue != null)
        {
            oldValue = newValue;

            OnPropertyChanged(propertyName);
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    private void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}