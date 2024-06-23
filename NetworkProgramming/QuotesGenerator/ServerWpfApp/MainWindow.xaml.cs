using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows;

namespace ServerWpfApp;

public partial class MainWindow : Window
{
    private TcpListener _tcpListener;
    private readonly List<string> _quotes;

    public MainWindow()
    {
        _quotes =
        [
            "\"Proin ac libero orci. Quisque a interdum nibh. Proin facilisis.\"",
            "\"Curabitur consequat maximus quam nec dictum. Mauris porttitor, neque id.\"",
            "\"Aliquam nisi metus, maximus at blandit vitae, iaculis eu mauris.\"",
            "\"Integer blandit urna eu justo vehicula, vel cursus felis ullamcorper.\"",
            "\"Vestibulum ante ipsum primis in faucibus orci luctus et ultrices.\"",
        ];
        InitializeComponent();
    }

    private void MainWindow_OnClosed(object sender, EventArgs e)
    {
        _tcpListener.Stop();
    }

    private async void StartButtonOnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _tcpListener = new TcpListener(IPAddress.Parse(IpAddressTextBox.Text), Convert.ToInt32(PortTextBox.Text));
            _tcpListener.Start();
            LogMessagesListBox.Items.Add($"[{DateTime.Now}] Server launched.");
            await Task.Run(MessageReceiveAsync);
        }
        catch (SocketException exception)
        {
            LogMessagesListBox.Items.Add($"[{DateTime.Now}] Socket exception: {exception.Message}");
        }
        catch (Exception exception)
        {
            LogMessagesListBox.Items.Add($"[{DateTime.Now}] Exception: {exception.Message}");
        }
    }

    private async Task MessageReceiveAsync()
    {
        while (true)
        {
            if (!_tcpListener.Pending()) continue;

            using var tcpClient = await _tcpListener.AcceptTcpClientAsync();
            await Dispatcher.InvokeAsync(() =>
                LogMessagesListBox.Items.Add($"[{DateTime.Now}] Подключился {tcpClient.Client.LocalEndPoint}"));
            
            var networkStream = tcpClient.GetStream();
            var sr = new StreamReader(networkStream, Encoding.Unicode);
            
            var message = await sr.ReadLineAsync() ?? string.Empty;
            if (message.Equals("GET QUOTE", StringComparison.OrdinalIgnoreCase))
            {
                var random = new Random();
                var quoteIndex = random.Next(0, _quotes.Count);
                var quote = _quotes[quoteIndex];
                
                var bytes = Encoding.Unicode.GetBytes(quote);
                await networkStream.WriteAsync(bytes);
                
                await Dispatcher.InvokeAsync(() => LogMessagesListBox.Items.Add($"[{DateTime.Now}] Добавлена цитата: {quote}"));
            }

            tcpClient.Close();
            await Dispatcher.InvokeAsync(() =>
                LogMessagesListBox.Items.Add($"[{DateTime.Now}] Отключился {tcpClient.Client.LocalEndPoint}"));


            if (!message.Equals("EXIT", StringComparison.OrdinalIgnoreCase)) continue;

            _tcpListener.Stop();
            Dispatcher.Invoke(Close);
        }
    }
}