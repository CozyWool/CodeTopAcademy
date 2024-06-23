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

namespace ContainersWpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        FullInfoButton.IsEnabled = nameTextBox.Text.Length > 0 && surnameTextBox.Text.Length > 0;
        ShortInfoButton.IsEnabled = nameTextBox.Text.Length > 0;
    }

    private void FullInfoButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show($"{nameTextBox.Text} {surnameTextBox.Text}");
    }

    private void ShortInfoButton_Click(object sender, RoutedEventArgs e)
    {

        MessageBox.Show($"{nameTextBox.Text}");
    }

    private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        FullInfoButton.IsEnabled = nameTextBox.Text.Length > 0 && surnameTextBox.Text.Length > 0;
        ShortInfoButton.IsEnabled = nameTextBox.Text.Length > 0;
    }
}
