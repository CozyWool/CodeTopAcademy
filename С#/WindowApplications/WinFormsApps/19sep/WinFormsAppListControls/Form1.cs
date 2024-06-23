using System.Text;

namespace WinFormsAppListControls;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        StringBuilder sb = new("Checked items:\n");
        foreach (var item in checkedListBox1.CheckedItems)
        {
            sb.AppendLine(item.ToString());
        };
        sb.AppendLine("Selected items:");
        foreach (var item in checkedListBox1.SelectedItems)
        {
            sb.AppendLine(item.ToString());
        };
        MessageBox.Show(sb.ToString());
    }
}
