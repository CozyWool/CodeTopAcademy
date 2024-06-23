using System.Windows.Forms;

namespace TextEditorWinForms;

public partial class Form1 : Form
{
    private string _fileName;
    private string _filePath;
    public Form1()
    {
        InitializeComponent();
        RefreshFilePath(Path.Combine(Application.StartupPath, "new.txt"));
    }

    private void RefreshFilePath(string newFilePath)
    {
        _filePath = newFilePath;
        _fileName = Path.GetFileName(_filePath);
        Text = _fileName + " - TextEditor";
    }

    private void LoadButton_Click(object sender, EventArgs e)
    {
        if (LoadFileDialog.ShowDialog() == DialogResult.OK)
        {
            using StreamReader sr = new(LoadFileDialog.FileName);
            RichTextBox.Text = sr.ReadToEnd();
            RefreshFilePath(LoadFileDialog.FileName);
        }
    }

    private void SaveAsButton_Click(object sender, EventArgs e)
    {
        if (SaveFileDialog.ShowDialog() == DialogResult.OK)
        {
            RefreshFilePath(SaveFileDialog.FileName);
            using StreamWriter sw = new(_filePath);
            sw.Write(RichTextBox.Text);
            MessageBox.Show($"Файл сохранен в {_fileName}");
        }
    }
    private void SaveButton_Click(object sender, EventArgs e)
    {
        using StreamWriter sw = new(_filePath);
        sw.Write(RichTextBox.Text);
        MessageBox.Show($"Файл сохранен в {_fileName}");
    }
    private void PasteTool_Click(object sender, EventArgs e)
    {
        RichTextBox.Text += Clipboard.GetText();
    }

    private void CutTool_Click(object sender, EventArgs e)
    {
        if (RichTextBox.SelectedText.Length > 0)
            Clipboard.SetText(RichTextBox.SelectedText);
        else if (RichTextBox.Text.Length > 0)
            Clipboard.SetText(RichTextBox.Text);
        RichTextBox.Text = string.Empty;
    }

    private void CopyTool_Click(object sender, EventArgs e)
    {
        if (RichTextBox.SelectedText.Length > 0)
            Clipboard.SetText(RichTextBox.SelectedText);
        else if (RichTextBox.Text.Length > 0)
            Clipboard.SetText(RichTextBox.Text);
    }

    private void BackgroundColor_Click(object sender, EventArgs e)
    {
        if (ColorDialog.ShowDialog() == DialogResult.OK)
        {
            BackColor = ColorDialog.Color;
        }
        else
        {
            BackColor = DefaultBackColor;
        }
    }

    private void NewDocument_Click(object sender, EventArgs e)
    {
        RefreshFilePath(Path.Combine(Application.StartupPath, "new.txt"));
        RichTextBox.Text = string.Empty;
    }

    private void SelectAll_Click(object sender, EventArgs e)
    {
        RichTextBox.SelectAll();
    }

    private void StyleFont_Click(object sender, EventArgs e)
    {
        if (FontDialog.ShowDialog() == DialogResult.OK)
        {
            RichTextBox.Font = FontDialog.Font;
        }
        else
        {
            RichTextBox.Font = FontDialog.Font;
        }
    }
}
