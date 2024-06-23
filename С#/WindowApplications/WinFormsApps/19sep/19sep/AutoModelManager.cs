namespace _19sep;

public partial class AutoModelManager : Form
{
    public AutoModelManager()
    {
        InitializeComponent();
    }

    private void CarTextBox_TextChanged(object sender, EventArgs e)
    {
        AddButton.Enabled = CarTextBox.Text.Length > 0;
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        CarListBox.Items.Add(CarTextBox.Text);
        CarTextBox.Clear();
    }

    private void CarListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        RemoveButton.Enabled = MoveToDestButton.Enabled = CarListBox.SelectedIndex != -1;
    }
    private void SelectedListBox_SelectedIndexChanged(object sender, EventArgs e)
    {
        MoveToSourceButton.Enabled = SelectedListBox.SelectedIndex != -1;
    }

    private void RemoveButton_Click(object sender, EventArgs e)
    {
        if (CarListBox.SelectedIndex == -1) return;
        CarListBox.Items.Remove(CarListBox.SelectedIndex);
    }

    private void MoveToDestButton_Click(object sender, EventArgs e)
    {
        var items = CarListBox.SelectedItems;
        if (items == null) return;

        while (items.Count > 0)
        {
            SelectedListBox.Items.Add(items[0]);
            CarListBox.Items.Remove(items[0]);
        }
    }


    private void MoveToSourceButton_Click(object sender, EventArgs e)
    {
        var items = SelectedListBox.SelectedItems;
        if (items == null) return;

        while (items.Count > 0)
        {
            CarListBox.Items.Add(items[0]);
            SelectedListBox.Items.Remove(items[0]);
        }
    }

    private void AddDialogButton_Click(object sender, EventArgs e)
    {
        var form = new AddCarForm();
        if (form.ShowDialog() == DialogResult.OK)
        {
            CarListBox.Items.Add(form.CarValue);
        }
    }
}
