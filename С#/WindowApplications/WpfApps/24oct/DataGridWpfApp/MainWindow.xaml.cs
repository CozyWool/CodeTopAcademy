using System.Windows;

namespace DataGridWpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        DataContext = new[]
        {
            new Employee("Иван", "Иванов", 23, false),
            new Employee("Пётр", "Петров", 24, true),
            new Employee("Сергей", "Сергеев", 30, true),
            new Employee("Алексей", "Алексеев", 29, false),

        };
    }
}
