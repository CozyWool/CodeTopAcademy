namespace MenuStripWinForms;

public partial class Form1 : Form
{
    private Color _color;
    public Form1()
    {
        InitializeComponent();
        _color = BackColor;
    }

    private void CloseTool_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void PasteTool_Click(object sender, EventArgs e)
    {
        richTextBox1.Text = Clipboard.GetText();
    }

    private void CutTool_Click(object sender, EventArgs e)
    {
        if (richTextBox1.SelectedText.Length > 0)
            Clipboard.SetText(richTextBox1.SelectedText);
        else if (richTextBox1.Text.Length > 0)
            Clipboard.SetText(richTextBox1.Text);
        richTextBox1.Text = string.Empty;
    }

    private void CopyTool_Click(object sender, EventArgs e)
    {
        if (richTextBox1.SelectedText.Length > 0)
            Clipboard.SetText(richTextBox1.SelectedText);
        else if (richTextBox1.Text.Length > 0)
            Clipboard.SetText(richTextBox1.Text);
    }

    private void RedTool_Click(object sender, EventArgs e)
    {
        var item = (ToolStripMenuItem)sender;
        BackColor = item.Checked ? Color.Red : _color;
    }
}
