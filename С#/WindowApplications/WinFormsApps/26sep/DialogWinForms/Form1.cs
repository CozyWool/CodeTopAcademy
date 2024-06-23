using System.Text;

namespace DialogWinForms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void OpenColorButton_Click(object sender, EventArgs e)
    {
        var colorDialog = new ColorDialog();
        colorDialog.AllowFullOpen = false;
        if (colorDialog.ShowDialog() == DialogResult.OK)
        {
            MessageBox.Show(colorDialog.Color.ToString());
        }
    }

    private void OpenFolderButton_Click(object sender, EventArgs e)
    {
        if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
        {
            MessageBox.Show(folderBrowserDialog1.SelectedPath);
        }
    }

    private void OpenFontButton_Click(object sender, EventArgs e)
    {
        if (fontDialog1.ShowDialog() == DialogResult.OK)
        {
            MessageBox.Show(fontDialog1.Font.ToString());
        }
    }

    private void OpenFileButton_Click(object sender, EventArgs e)
    {
        openFileDialog1.Multiselect = true;
        openFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
        if (openFileDialog1.ShowDialog() == DialogResult.OK)
        {
            StringBuilder sb = new();
            foreach (var item in openFileDialog1.FileNames)
            {
                sb.Append(item + "\n");
            }
            MessageBox.Show(sb.ToString());
        }
    }

    private void SaveFileButton_Click(object sender, EventArgs e)
    {
        saveFileDialog1.Filter = "Текстовые файлы (*.txt)|*.txt|Все файлы (*.*)|*.*";
        if (saveFileDialog1.ShowDialog() == DialogResult.OK)
        {
            MessageBox.Show(saveFileDialog1.FileName);
        }
    }
}
