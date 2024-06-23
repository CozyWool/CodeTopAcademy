using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace BindingWpfApp;
/// <summary>
/// Логика взаимодействия для LocalizationModuleWindow.xaml
/// </summary>
public partial class LocalizationModuleWindow : Window
{
    public LocalizationModuleWindow()
    {
        InitializeComponent();
    }

    public LocalzationTypes LocalizationType { get; set; }

    private void okButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        LocalizationType = GetLocalizationType();
        Close();
    }

    private LocalzationTypes GetLocalizationType()
    {
        return localComboBox.SelectedIndex switch
        {
            0 => LocalzationTypes.Russian,
            1 => LocalzationTypes.Espanol,
            _ => LocalzationTypes.Russian,
        };
    }

    private void cancelButton_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}
