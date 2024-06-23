namespace SecondHWWinFormsApp;
public partial class Task1Form : Form
{
    public Task1Form()
    {
        InitializeComponent();
    }

    private void OpenFile_Click(object sender, EventArgs e)
    {
        if (openFileDialog.ShowDialog() == DialogResult.OK)
        {
            using StreamReader sr = new(openFileDialog.FileName);
            string text = sr.ReadToEnd();
            progressBar.Minimum = 0; 
            progressBar.Maximum = text.Length - 1;
            for (int i = 0; i < text.Length; i++)
            {
                richTextBox1.Text += text[i];
                progressBar.Value = i;
                Thread.Sleep(10);
            }
        }
    }
}
