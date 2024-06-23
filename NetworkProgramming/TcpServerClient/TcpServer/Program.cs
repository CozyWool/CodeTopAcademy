using System.Net;
using System.Net.Sockets;
using System.Text;

var serverSocket = new Socket(AddressFamily.InterNetwork,
    SocketType.Stream,
    ProtocolType.Tcp);

var address = IPAddress.Parse("127.0.0.1");
var endPoint = new IPEndPoint(address, 1024);

serverSocket.Bind(endPoint);
serverSocket.Listen(10);

await StartAsync();

void Start()
{
    try
    {
        while (true)
        {
            var clientSocket = serverSocket.Accept();
            Console.WriteLine(clientSocket.RemoteEndPoint);
            var buffer = new byte[1024];
            int length;
            do
            {
                length = clientSocket.Receive(buffer);
                Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, length));
            } while (length > 0);
        
            Console.WriteLine();
            var message = $"Hello client. Time {DateTime.Now}";
            clientSocket.Send(Encoding.ASCII.GetBytes(message));
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }
    catch (SocketException exception)
    {
        Console.WriteLine(exception.Message);
    }
}


//AsyncVersion
async Task StartAsync()
{
    try
    {
        while (true)
        {
            var clientSocket = await serverSocket.AcceptAsync();
            Console.WriteLine(clientSocket.RemoteEndPoint);
            var buffer = new byte[1024];
            int length;
            do
            {
                length = await clientSocket.ReceiveAsync(buffer);
                Console.WriteLine(Encoding.ASCII.GetString(buffer, 0, length));
            } while (length > 0);
        
            Console.WriteLine();
            var message = $"Hello client. Time {DateTime.Now}";
            await clientSocket.SendAsync(Encoding.ASCII.GetBytes(message));
            clientSocket.Shutdown(SocketShutdown.Both);
            clientSocket.Close();
        }
    }
    catch (SocketException exception)
    {
        Console.WriteLine(exception.Message);
    }
}