namespace _19sep;

public partial class AddCarForm : Form
{
    public AddCarForm()
    {
        InitializeComponent();
    }

    public string CarValue => CarTextBox.Text;

    private void CancelButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void CarTextBox_TextChanged(object sender, EventArgs e)
    {
        OkButton.Enabled = CarValue.Length > 0;
    }
}
