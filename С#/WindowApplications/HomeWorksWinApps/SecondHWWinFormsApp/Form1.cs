namespace SecondHWWinFormsApp;

public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }

    private void Task1Button_Click(object sender, EventArgs e)
    {
        var form = new Task1Form();
        form.Show();
    }

    private void Task2Button_Click(object sender, EventArgs e)
    {
        var form = new Task2Form();
        form.Show();
    }
}
