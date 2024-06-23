using System.Net;
using System.Net.Sockets;
using System.Text;

try
{
    var (ipAddress, remotePort, localPort) = InitSettings();
    Task.Run(() => ReceiveAsync(localPort));
    Console.ForegroundColor = ConsoleColor.Red;
    while (true)
    {
        await SendDataAsync(Console.ReadLine(), ipAddress, remotePort);
    }
}
catch (FormatException exception)
{
    Console.WriteLine($"Conversion exception: {exception.Message}");
}
catch (Exception exception)
{
    Console.WriteLine($"Exception: {exception.Message}");
}

(IPAddress ipAddress, int remotePort, int localPort) InitSettings()
{
    Console.SetWindowSize(40, 20);
    Console.Title = "Chat";
    Console.Write("Enter remote IP: ");
    var remoteIpAddress = IPAddress.Parse(Console.ReadLine());

    Console.Write("Enter remote port: ");
    var remotePort = Convert.ToInt32(Console.ReadLine());

    Console.Write("Enter local port: ");
    var localPort = Convert.ToInt32(Console.ReadLine());

    return (remoteIpAddress, remotePort, localPort);
}

async Task ReceiveAsync(object parameter)
{
    if (parameter is not int localPort) return;
    try
    {
        while (true)
        {
            var client = new UdpClient(localPort);
            IPEndPoint endPoint = null;
            
            var response = await client.ReceiveAsync();
            var message = Encoding.UTF8.GetString(response.Buffer);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"Получено сообщение от {response.RemoteEndPoint.Address}:{response.RemoteEndPoint.Port} - {message}");
            Console.ForegroundColor = ConsoleColor.Red;
            client.Close();
        }
    }
    catch (SocketException exception)
    {
        Console.WriteLine($"Socket exception: {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Exception: {exception.Message}");
    }
}

async Task SendDataAsync(string datagram, IPAddress address, int port)
{
    var client = new UdpClient();
    var endPoint = new IPEndPoint(address, port);
    try
    {
        var buffer = Encoding.UTF8.GetBytes(datagram);
        await client.SendAsync(buffer, buffer.Length, endPoint);
    }
    catch (SocketException exception)
    {
        Console.WriteLine($"Socket exception: {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Exception: {exception.Message}");
    }
    finally
    {
        client.Close();
    }
}