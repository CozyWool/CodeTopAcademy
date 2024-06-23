using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;
using System.Windows.Threading;

namespace Server;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private TcpListener _tcpListener;

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void StartButtonOnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _tcpListener = new TcpListener(IPAddress.Parse(IpAddressTextBox.Text), Convert.ToInt32(PortTextBox.Text));
            _tcpListener.Start();
            MessageBox.Show("Сервер запущен и готов к работе!");
            await Task.Run(MessageReceiveAsync);
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


    private async Task MessageReceiveAsync()
    {
        while (true)
        {
            if (!_tcpListener.Pending()) continue;
    
            var tcpCLient = await _tcpListener.AcceptTcpClientAsync();
            var sr = new StreamReader(tcpCLient.GetStream(), Encoding.Unicode);
            // MessageBox.Show("Поток получен!");
            var message = await sr.ReadLineAsync() ?? string.Empty;
            await Dispatcher.InvokeAsync(() => MessagesListBox.Items.Add(message));
            // MessageBox.Show("Сообщение выведено!");
            tcpCLient.Close();
    
            if (message.ToUpper() != "EXIT") continue;
    
            _tcpListener.Stop();
            Dispatcher.Invoke(Close);
        }
    }
    private void MainWindow_OnClosed(object? sender, EventArgs e)
    {
        _tcpListener.Stop();
    }
}