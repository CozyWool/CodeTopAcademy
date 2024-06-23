using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace StudentCollectionWpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private DataSource dataSource = new DataSource();
    public MainWindow()
    {
        InitializeComponent();
        dataSource.AddValueToStudentCollection(new(0, "Пётр", 30));
        dataSource.AddValueToStudentCollection(new(1, "Сергей", 100));
        DataContext = dataSource;
    }

    private void AddStudentButton_Click(object sender, RoutedEventArgs e)
    {
        var addStudentWindow = new AddStudent();
        if ((bool)addStudentWindow.ShowDialog())
        {
            dataSource.AddValueToStudentCollection(addStudentWindow.student);
        }
    }
}
