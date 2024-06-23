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
using System.Windows.Threading;

namespace TaskWpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void StartButton_OnClick(object sender, RoutedEventArgs e)
    {
        StateTextBlock.Text = "Идёт работа...";
        StartButton.IsEnabled = false;
        TaskProgress.Visibility = Visibility.Visible;
        TaskProgress.Value = 0;

        var task = new Task(() =>
        {
            for (var i = 0; i < 100; i++)
            {
                Thread.Sleep(100);
                Dispatcher.Invoke(() => { TaskProgress.Value = i + 1; });
            }
        });
        task.ContinueWith(t =>
        {
            Dispatcher.Invoke(() =>
            {
                StateTextBlock.Text = "Работа завершена";
                StartButton.IsEnabled = true;
                TaskProgress.Visibility = Visibility.Collapsed;
            });
        }, TaskContinuationOptions.OnlyOnRanToCompletion);

        task.Start();
    }
}