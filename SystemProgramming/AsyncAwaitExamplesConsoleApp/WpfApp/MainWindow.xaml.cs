using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    // private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    // {
    //     var schedluer = TaskScheduler.FromCurrentSynchronizationContext();
    //     Task.Factory.StartNew(() =>
    //         {
    //             for (int i = 0; i < 100; i++)
    //             {
    //                 Task.Delay(50);
    //             }
    //
    //             return "Посчитали числа от 0 до 100";
    //         })
    //         .ContinueWith(action => InfoTextBlock.Text = action.Result, schedluer);
    // }

    private void ButtonBase_OnClick(object sender, RoutedEventArgs e)
    {
        FooBarAsync().Wait();
        InfoTextBlock.Text = "new text";
    }

    private static async Task FooBarAsync()
    {
        // await Task.Delay(3000);
        await Task.Delay(3000).ConfigureAwait(false);
        MessageBox.Show("Ta-dam!");
    }
}