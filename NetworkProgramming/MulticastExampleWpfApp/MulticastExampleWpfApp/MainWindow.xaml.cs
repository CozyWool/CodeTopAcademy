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

namespace MulticastExampleWpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private IPAddress _multicastAddress = IPAddress.Parse("224.5.5.5");

    public MainWindow()
    {
        InitializeComponent();
    }

    private async void SendButton_OnClick(object sender, RoutedEventArgs e)
    {
        var client = new UdpClient();
        var message = MessageTextBox.Text;
        var bytes = Encoding.UTF8.GetBytes(message);
        var port = Convert.ToInt32(PortTextBox.Text);
        var endPoint = new IPEndPoint(_multicastAddress, port);
        await client.SendAsync(bytes, endPoint);
    }

    private async Task ReceiveMessages()
    {
        var port = await Dispatcher.InvokeAsync(() => Convert.ToInt32(PortTextBox.Text));
        var client = new UdpClient(port);

        client.JoinMulticastGroup(_multicastAddress);
        await Dispatcher.InvokeAsync(() =>
        {
            MessagesTextBox.Text += "Слушаем";
            MessagesTextBox.Text += Environment.NewLine;
        });
        while (true)
        {
            var udpReceiveResult = await client.ReceiveAsync();
            var bytes = udpReceiveResult.Buffer;
            var remoteAddress = udpReceiveResult.RemoteEndPoint;
            var message = Encoding.UTF8.GetString(bytes);
            if (message.Equals("end", StringComparison.OrdinalIgnoreCase))
            {
                break;
            }

            await Dispatcher.InvokeAsync(() =>
            {
                MessagesTextBox.Text += $"{remoteAddress.Address}:{remoteAddress.Port}. {message}";
                MessagesTextBox.Text += Environment.NewLine;
            });
        }
        
        client.Close();
    }

    private async void ListenButton_OnClick(object sender, RoutedEventArgs e)
    {
        await Task.Run(ReceiveMessages);
    }
}