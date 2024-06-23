using System.Net;
using System.Net.Http;
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
using Newtonsoft.Json;

namespace TDSClientWpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void PostButton_OnClick(object sender, RoutedEventArgs e)
    {
        var toDoTask = new ToDoTask
        {
            Id = Convert.ToInt32(IdTextBox.Text),
            Name = NameTextBox.Text,
            Description = DescriptionTextBox.Text,
            CreateDate = DateTime.Now,
            DeadlineDate = DateTime.Now.AddDays(2),
            IsCompleted = IsCompletedCheckBox.IsChecked.Value
        };
        var jsonContent = JsonConvert.SerializeObject(toDoTask);
        var client = new HttpClient();
        var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:5105/tasks");
        var content = new StringContent(jsonContent, null, "application/json");
        request.Content = content;
        var response = await client.SendAsync(request);
        if (response.StatusCode == HttpStatusCode.OK)
        {
            MessageBox.Show("Данные отправлены!");
        }
    }
}