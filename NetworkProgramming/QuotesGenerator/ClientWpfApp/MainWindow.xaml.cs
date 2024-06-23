using System.IO;
using System.Net;
using System.Net.Sockets;
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

namespace ClientWpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private TcpClient _tcpClient;

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void SendButtonOnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            var endPoint = new IPEndPoint(IPAddress.Parse(IpAddressTextBox.Text), Convert.ToInt32(PortTextBox.Text));
            _tcpClient = new TcpClient();

            await _tcpClient.ConnectAsync(endPoint);
            var networkStream = _tcpClient.GetStream();
            var bytes = Encoding.Unicode.GetBytes("GET QUOTE");
            await networkStream.WriteAsync(bytes);
            
            await Task.Run(MessageReceiveAsync);
            _tcpClient.Close();
        }
        catch (SocketException exception)
        {
            QuotesListBox.Items.Add($"[{DateTime.Now}] Socket exception: {exception.Message}");
        }
        catch (Exception exception)
        {
            QuotesListBox.Items.Add($"[{DateTime.Now}] Exception: {exception.Message}");
        }
    }

    private async Task MessageReceiveAsync()
    {
        if (!_tcpClient.Connected) return;

        var networkStream = _tcpClient.GetStream();
        var sr = new StreamReader(networkStream, Encoding.Unicode);

        var message = await sr.ReadLineAsync() ?? $"[{DateTime.Now}] Произошла ошибка :/";
        await Dispatcher.InvokeAsync(() => QuotesListBox.Items.Add($"[{DateTime.Now}] Полученная цитата: {message}"));
    }

    private void MainWindow_OnClosed(object sender, EventArgs e)
    {
        _tcpClient.Close();
    }
}