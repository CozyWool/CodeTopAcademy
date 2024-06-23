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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace StudentBindingWpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Student student;
    public MainWindow()
    {
        InitializeComponent();
        student = new Student
        {
            Id = 34,
            Name = "Иван",
            Surname = "Иванов",
            DateBirth = DateTime.Now,
        };
        DataContext = student;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        student.Name = "Пётр";
        resultTextBox.Text = student.ToString();
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        MessageBox.Show(student.ToString());
    }
}
