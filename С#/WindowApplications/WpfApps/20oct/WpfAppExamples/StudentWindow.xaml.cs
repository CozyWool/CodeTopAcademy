using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfAppExamples;
/// <summary>
/// Логика взаимодействия для StudentWindow.xaml
/// </summary>
public partial class StudentWindow : Window
{
    public StudentWindow(Window owner)
    {
        Owner = owner;
        InitializeComponent();
        Student = new Student();
        DataContext = Student;
    }
    
    public Student Student { get; private set; }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    private void CancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}
