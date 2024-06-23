using System.Diagnostics;
using System.Windows;

namespace CalcProcessWpfApp;

public partial class MainWindow : Window
{
    private Process _calcProcess;
    public MainWindow()
    {
        InitializeComponent();
        _calcProcess = new Process();
        _calcProcess.StartInfo = new ProcessStartInfo(@"C:\Program Files\Notepad++\notepad++.exe");
    }

    private void StartButton_OnClick(object sender, RoutedEventArgs e)
    {
        _calcProcess = new Process();
        _calcProcess.StartInfo = new ProcessStartInfo(@"C:\Program Files\Notepad++\notepad++.exe");
        _calcProcess.Start();
    }

    private void StopButton_OnClick(object sender, RoutedEventArgs e)
    {
        _calcProcess.CloseMainWindow();
        _calcProcess.Close();
    }
}