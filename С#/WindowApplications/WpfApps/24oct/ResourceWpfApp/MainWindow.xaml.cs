using System.Windows;
using WpfAppCollections;

namespace ResourceWpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly Person person;

    public MainWindow()
    {
        InitializeComponent();
        person = new Person();
        DataContext = person;
    }

    private void OkButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show($"{person.Name} {person.Surname}");
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
    }
}