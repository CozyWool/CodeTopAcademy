using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows;

namespace ManipulationWpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    [DllImport("user32.dll")]
    public static extern IntPtr SendMessage(IntPtr hwnd,
        uint wMsg,
        int wParam,
        [MarshalAs(UnmanagedType.LPStr)] string lParam);

    public MainWindow()
    {
        InitializeComponent();
    }

    private void Child1_OnClick(object sender, RoutedEventArgs e)
    {
        var process = new Process();
        process.StartInfo = new ProcessStartInfo("ChildOneWpf.exe");
        process.Start();
        SendMessage(process.MainWindowHandle, 0x0C, 0, "Child window one");
    }

    private void Child2_OnClick(object sender, RoutedEventArgs e)
    {
        var process = new Process();
        process.StartInfo = new ProcessStartInfo("ChildTwoWpf.exe");
        process.Start();
        SendMessage(process.MainWindowHandle, 0x0C, 0, "Child window two");
    }
}