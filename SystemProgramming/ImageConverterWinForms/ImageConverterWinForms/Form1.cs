using System.Diagnostics;
using ImageConverterWinForms.Algorithms;

namespace ImageConverterWinForms;

// https://vscode.ru/prog-lessons/preobrazovanie-tsvetnogo-izobrazheniya-v-cherno-beloe.html?ysclid=lsybhok3js315382094
public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void openToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var openFileDialog = new OpenFileDialog();
        openFileDialog.Filter =
            @"Image Files(*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG)|*.BMP;*.JPG;*.JPEG;*.GIF;*.PNG|All files (*.*)|*.*";
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            try
            {
                sourcePictureBox.Image = new Bitmap(openFileDialog.FileName);
            }
            catch
            {
                MessageBox.Show(@"Невозможно открыть выбранный файл", @"Ошибка",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    private void saveToolStripMenuItem_Click(object sender, EventArgs e)
    {
        if (destinationPictureBox.Image != null)
        {
            var sfd = new SaveFileDialog();
            sfd.Title = @"Сохранить картинку как...";
            sfd.OverwritePrompt = true;
            sfd.CheckPathExists = true;
            sfd.Filter =
                @"Image Files(*.BMP)|*.BMP|Image Files(*.JPG)|*.JPG|Image Files(*.GIF)|*.GIF|Image Files(*.PNG)|*.PNG|All files (*.*)|*.*";
            sfd.ShowHelp = true;
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    destinationPictureBox.Image.Save(sfd.FileName);
                }
                catch
                {
                    MessageBox.Show(@"Невозможно сохранить изображение", @"Ошибка",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }

    private void closeToolStripMenuItem_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void singleThreadedToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        if (sourcePictureBox.Image != null)
        {
            var singleThreadedImageConverter = new SingleThreadedImageConverter();
            var output = singleThreadedImageConverter.ConvertToGray(new Bitmap(sourcePictureBox.Image));
            destinationPictureBox.Image = output;
        }

        stopwatch.Stop();
        MessageBox.Show($@"Time: {stopwatch.Elapsed}");
    }

    private void multithreadedToolStripMenuItem_Click(object sender, EventArgs e)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        if (sourcePictureBox.Image != null)
        {
            var multithreadedImageConverter = new MultithreadedImageConverter();
            var output = multithreadedImageConverter.ConvertToGray(new Bitmap(sourcePictureBox.Image));
            destinationPictureBox.Image = output;
        }

        stopwatch.Stop();
        MessageBox.Show($@"Time: {stopwatch.Elapsed}");
    }
}