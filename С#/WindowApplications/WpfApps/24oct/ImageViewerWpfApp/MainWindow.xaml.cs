using Microsoft.Win32;
using System;
using System.Windows;
using System.Windows.Media.Imaging;

namespace ImageViewerWpfApp;
/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OpenImageButton_Click(object sender, RoutedEventArgs e)
    {
        var dialog = new OpenFileDialog()
        {
            Title = "Выберите изображение",
            Filter = "Картинки|*.png;*.jpg;*.gif;*.bmp"
        };
        if (dialog.ShowDialog() == true)
        {
            try
            {
                var image = new BitmapImage(new Uri(dialog.FileName));
                _image.Source = image;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка открытия картинки");
            }
        }
    }
}
