using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DialogsWinFormsApp;
public partial class AddStudentForm : Form
{
    private Student student;
    public AddStudentForm()
    {
        InitializeComponent();
    }

    public Student GetEditedStudent()
    {
        return new Student(int.Parse(IdTextBox.Text),
                           NameTextBox.Text,
                           GroupTextBox.Text);
    }

    private void OkButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private void CancelButton_Click(object sender, EventArgs e)
    {
        Close();
    }

    private bool CheckText()
    {
        return IdTextBox.Text.Length > 0 && NameTextBox.Text.Length > 0 && GroupTextBox.Text.Length > 0;
    }

    private void TextBox_TextChanged(object sender, EventArgs e)
    {
        OkButton.Enabled = CheckText();
    }
}
