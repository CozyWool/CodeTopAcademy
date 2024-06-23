using System.Net;
using System.Net.Http;
using System.Text;
using System.Windows;

namespace Client;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void SendRequestButton_OnClick(object sender, RoutedEventArgs e)
    {
        ServerResponseTextBox.Text = "Пытаемся подключиться к серверу:\n";
        var message = await GetReponseAsync("http://127.0.0.1:1234");
        ServerResponseTextBox.Text += message;
    }

    private static async Task<string> GetReponseAsync(string url)
    {
        try
        {
            var sb = new StringBuilder();
            using var client = new HttpClient();
            var response = await client.GetAsync(url);

            if(response.StatusCode != HttpStatusCode.OK)
            {
                return $"Запрос не был выполнен. Код ответа: {response.StatusCode}";
            }
            
            var responseHeaders = response.Headers.ToString();
            var content = await response.Content.ReadAsStringAsync();
        
            sb.AppendLine("Response headers: ");
            sb.AppendLine(responseHeaders);
            sb.AppendLine("Response body: ");
            sb.AppendLine(content);

            return sb.ToString();
        }
        catch (HttpRequestException exception)
        {
            return $"Произошла ошибка: {exception.Message}";
        }
    }
}