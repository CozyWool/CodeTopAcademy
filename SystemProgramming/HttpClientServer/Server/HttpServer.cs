using System.Net;

namespace Server;

public class HttpServer
{
    private readonly HttpListener _httpListener;

    private const string ResponseTemplate =
        "<html><head><title>Test</title></head><body><h2>Test page</h2><h4>Today is: {0}</h4></body></html>";

    public HttpServer(int portNumber)
    {
        // localhost - 127.0.0.1
        _httpListener = new HttpListener();
        _httpListener.Prefixes.Add($"http://127.0.0.1:{portNumber}/");
    }

    public async Task Start()
    {
        _httpListener.Start();
        while (true)
        {
            var ctx = await _httpListener.GetContextAsync();
            Console.WriteLine("Клиент подключился к серверу....");
            var response = string.Format(ResponseTemplate, DateTime.Now);

            await using var sw = new StreamWriter(ctx.Response.OutputStream);
            await sw.WriteAsync(response);
            await sw.FlushAsync();
        }
    }

    public Task Stop()
    {
        _httpListener.Stop();
        return Task.CompletedTask;
    }
}