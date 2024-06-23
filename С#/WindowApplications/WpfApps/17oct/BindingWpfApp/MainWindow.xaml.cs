using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace BindingWpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void okButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void cancelButton_Click(object sender, RoutedEventArgs e)
    {

    }

    private void changeLocalizationButton_Click(object sender, RoutedEventArgs e)
    {
        //Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es");
        var w = new LocalizationModuleWindow();
        if (w.ShowDialog() == true)
        {
            switch (w.LocalizationType)
            {
                case LocalzationTypes.Russian:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("ru");
                    break;
                case LocalzationTypes.Espanol:
                    Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo("es");
                    break;
                default:
                    break;
            }
        }
        UpdateUI();
    }

    private void Window_Loaded(object sender, RoutedEventArgs e)
    {
        UpdateUI();
    }

    private void UpdateUI()
    {
        nameTextBlock.Text = Strings.Name;
        surnameTextBlock.Text = Strings.Surname;
        phoneTextBlock.Text = Strings.Phone;

        okButton.Content = Strings.Ok;
        cancelButton.Content = Strings.Cancel;
    }
}
