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
public partial class StudentDetailsForm : Form
{
    private Student student;
    public StudentDetailsForm(Student student)
    {
        InitializeComponent();
        this.student = student;
        IdTextBox.Text = student.Id.ToString();
        NameTextBox.Text = student.Name;
        GroupTextBox.Text = student.Group;
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
}
