namespace EditorWinForms;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void LoadButton_Click(object sender, EventArgs e)
    {
        if (LoadFileDialog.ShowDialog() == DialogResult.OK)
        {
            using StreamReader sr = new(LoadFileDialog.FileName);
            RichTextBox.Text = sr.ReadToEnd();
        }
    }

    private void SaveButton_Click(object sender, EventArgs e)
    {
        if (SaveFileDialog.ShowDialog() == DialogResult.OK)
        {
            using StreamWriter sw = new(SaveFileDialog.FileName);
            sw.Write(RichTextBox.Text);
            MessageBox.Show($"Файл сохранен в {SaveFileDialog.FileName}");
        }
    }
}
