using System.Configuration;
using System.Data;
using System.Windows;

namespace MutexWpfApp;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    private const string MutexName = "MutexWpfExample";
    private Mutex _mutex;
    protected override void OnStartup(StartupEventArgs e)
    {
        base.OnStartup(e);
        _mutex = new Mutex(true, MutexName, out var createdNew);
        if (!createdNew)
        {
            MessageBox.Show("Программа уже существует");
            Current.Shutdown();
            return;
        }
        var mainWindow = new MainWindow();
        mainWindow.Show();
    }
}