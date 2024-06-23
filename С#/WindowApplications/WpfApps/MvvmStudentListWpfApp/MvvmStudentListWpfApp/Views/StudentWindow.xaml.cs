using System.Windows;

namespace MvvmStudentListWpfApp.Views;

public partial class StudentWindow : Window
{
    public StudentWindow(Window owner)
    {
        Owner = owner;
        InitializeComponent();
    }
}