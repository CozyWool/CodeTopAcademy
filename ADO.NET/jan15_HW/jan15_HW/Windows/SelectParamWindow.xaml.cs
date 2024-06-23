using System.Windows;
using System.Windows.Controls;

namespace jan15_HW.Windows;

public partial class SelectParamWindow : Window
{
    private readonly int _minParamLength;
    public string Param { get; private set; }
    public SelectParamWindow(string textBlockText, int minParamLength)
    {
        InitializeComponent();
        TextBlock.Text = textBlockText;
        Title = textBlockText;
        _minParamLength = minParamLength;
        
        OkButton.IsEnabled = false;
    }

    
    private void Ok_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = true;
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        Close();
    }

    private void TextBoxBase_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        Param = TextBox.Text;
        OkButton.IsEnabled = Param.Length >= _minParamLength;
    }
}