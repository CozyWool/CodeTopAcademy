using System.Windows;

namespace ValidationRuleFive
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new Person("Programmer", 10, "Ivan");
        }
    }
}