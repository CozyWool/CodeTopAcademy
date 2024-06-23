
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

namespace WpfAppExamples;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private DataSource _dataSource;
    public MainWindow()
    {
        InitializeComponent();
        DataContext = _dataSource = CreateDataSource();
    }

    private DataSource CreateDataSource()
    {
        var dataSource = new DataSource();
        dataSource.AddStudent(new Student(1, "Ivan", 12));
        dataSource.AddStudent(new Student(2, "Petr", 12));
        return dataSource;
    }

    private void Button_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new StudentWindow(this);
        if (dialog.ShowDialog() == true)
        {
            _dataSource.AddStudent(dialog.Student);
        }
    }

    private void SelectedStudent_Click(object sender, RoutedEventArgs e)
    {
        if (_dataSource.CurrentStudent == null) 
        {
            MessageBox.Show("Студент не выбран");
            return;
        }

        MessageBox.Show(_dataSource.CurrentStudent.ToString());
    }

    private void Button_Click_1(object sender, RoutedEventArgs e)
    {
        var button = (Button)sender;
        var student = button.DataContext as Student;

    }
}
