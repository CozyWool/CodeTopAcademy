using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows;

namespace WpfAppCollections;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    //private CustonCollection<Person> _persons; 
    private readonly ObservableCollection<Person> _persons;
    public MainWindow()
    {
        InitializeComponent();
        //_persons = new CustonCollection<Person>();
        _persons = new ObservableCollection<Person>();
        _persons.Add(new Person("Ivan", 33));
        _persons.Add(new Person("Petr", 23));
        _persons.CollectionChanged += _persons_CollectionChanged;

        _list.ItemsSource = _persons;
    }

    private void _persons_CollectionChanged(object? sender, NotifyCollectionChangedEventArgs e)
    {
        if (e.Action == NotifyCollectionChangedAction.Add)
        {
            // some code...
        }
    }

    private void _addButton_Click(object sender, RoutedEventArgs e)
    {
        _persons.Add(new Person("John Doe", 27));
    }
}
