using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace Client;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private TcpClient? _tcpClient = null;

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
            var bytes = Encoding.Unicode.GetBytes(MessageTextBox.Text);
            await networkStream.WriteAsync(bytes);
            _tcpClient.Close();
        }
        catch (SocketException exception)
        {
            MessageBox.Show($"Socket exception: {exception.Message}");
        }
        catch (Exception exception)
        {
            MessageBox.Show($"Exception: {exception.Message}");
        }
    }

    private void MainWindow_OnClosed(object? sender, EventArgs e)
    {
        _tcpClient?.Close();
    }
}