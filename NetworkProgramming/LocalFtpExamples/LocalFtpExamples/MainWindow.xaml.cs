using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using LocalFtpExamples.Enums;
using LocalFtpExamples.Models;
using Microsoft.Win32;

namespace LocalFtpExamples;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private async void UploadButton_OnClick(object sender, RoutedEventArgs e)
    {
        var openFileDialog = new OpenFileDialog();
        if (openFileDialog.ShowDialog(this) != true) return;
        var uri = $"ftp://127.0.0.1/{System.IO.Path.GetFileName(openFileDialog.FileName)}";
        var request = (FtpWebRequest) WebRequest.Create(uri);
        request.Method = WebRequestMethods.Ftp.UploadFile;

        var requestStream = await request.GetRequestStreamAsync();
        await using var fs = new FileStream(openFileDialog.FileName, FileMode.Open);
        await fs.CopyToAsync(requestStream);
        fs.Close();
        requestStream.Close();
        MessageBox.Show("Загрузка файлов завершена");
    }

    private async void DownloadButton_OnClick(object sender, RoutedEventArgs e)
    {
        var saveFileDialog = new SaveFileDialog();
        if (saveFileDialog.ShowDialog(this) != true) return;
        var request = (FtpWebRequest) WebRequest.Create("ftp://127.0.0.1/test.txt");
        request.Method = WebRequestMethods.Ftp.DownloadFile;
        var response = (FtpWebResponse) request.GetResponse();
        var responseStream = response.GetResponseStream();
        await using var fs = new FileStream(saveFileDialog.FileName, FileMode.Create);
        await responseStream.CopyToAsync(fs);
        fs.Close();
        response.Close();
        MessageBox.Show("Сохранение файла завершено");
    }

    private async void ListButton_OnClick(object sender, RoutedEventArgs e)
    {
        var regex = new Regex(@"(\d{2}-\d{2}-\d{2}\s+\d{1,2}:\d{2}\w+)\s+(<DIR>)?(\d{1,})?\s+(.+)",
            RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase |
            RegexOptions.IgnorePatternWhitespace);
        var request = (FtpWebRequest)WebRequest.Create("ftp://127.0.0.1/");
        request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
        var response = (FtpWebResponse)request.GetResponse();
        var responseStream = response.GetResponseStream();
        var fileDirectoryItems = new List<FileDirectoryInfo>();
        using var sr = new StreamReader(responseStream);
        while (!sr.EndOfStream)
        {
            var line = await sr.ReadLineAsync();
            if (string.IsNullOrEmpty(line)) continue;
            var match = regex.Match(line);
            fileDirectoryItems.Add(CreateFileDirectoryInfo(match));
        }

        FilesDataGrid.ItemsSource = fileDirectoryItems;
    }
    private static FileDirectoryInfo CreateFileDirectoryInfo(Match match) => new()
    {
        Type = match.Groups[2].Value.Length > 0 ? FileTypes.Directory : FileTypes.File,
        FileSize = match.Groups[3].Value,
        Name = match.Groups[4].Value,
        Date = DateTime.Parse(match.Groups[1].Value)
    };
}