using System.Windows;
using System.Windows.Controls;

namespace jan15_HW.Windows;

public partial class SelectTwoParamsWindow : Window
{
    private readonly int _minParamLength;
    public string Param1 { get; private set; }
    public string Param2 { get; private set; }
    
    // Костыльно, но не хочу делать модальное окно на коллекции и динамически заполнять grid, т.к цель ДЗ не в этом
    public SelectTwoParamsWindow(string windowTitle,string textBlock1Text, string textBlock2Text,int minParamLength)
    {
        InitializeComponent();
        TextBlock1.Text = textBlock1Text;
        TextBlock2.Text = textBlock2Text;
        Title = windowTitle;
        _minParamLength = minParamLength;
        Param1 = "";
        Param2 = "";
        
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

    private void TextBox1Base_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        Param1 = TextBox1.Text;
        OkButton.IsEnabled = Param1.Length >= _minParamLength && Param2.Length >= _minParamLength;
    }
    
    private void TextBox2Base_OnTextChanged(object sender, TextChangedEventArgs e)
    {
        Param2 = TextBox2.Text;
        OkButton.IsEnabled = Param1.Length >= _minParamLength && Param2.Length >= _minParamLength;
    }
}