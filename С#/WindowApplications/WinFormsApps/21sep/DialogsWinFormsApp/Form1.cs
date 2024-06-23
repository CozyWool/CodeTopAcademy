using System.Windows.Forms;

namespace DialogsWinFormsApp;
public partial class Form1 : Form
{
    private List<Student> _students;
    public Form1()
    {
        InitializeComponent();
        InitStudents();
        DeleteButton.Enabled = dataGridView1.SelectedRows.Count != 0;
    }

    private void InitStudents()
    {
        _students = new List<Student>
        {
            new(1, "Иванов", "123"),
            new(1, "Петров", "123"),
            new(1, "Сидоров", "123"),
            new(1, "Алексеев", "123")
        };
        dataGridView1.DataSource = _students;
    }

    private void EditButton_Click(object sender, EventArgs e)
    {
        if (dataGridView1.SelectedRows.Count == 0)
        {
            MessageBox.Show("");
            return;
        }
        var index = dataGridView1.SelectedRows[0].Index;
        var form = new StudentDetailsForm(_students[index]);
        if (form.ShowDialog() == DialogResult.OK)
        {
            var newStudent = form.GetEditedStudent();
            _students[index].Id = newStudent.Id;
            _students[index].Name = newStudent.Name;
            _students[index].Group = newStudent.Group;
            dataGridView1.Update();
        }
    }

    private void dataGridView1_SelectionChanged(object sender, EventArgs e)
    {
        // С самого начала выбран первый студент, поэтому не работает
        DeleteButton.Enabled = dataGridView1.SelectedRows.Count != 0;
    }

    private void DeleteButton_Click(object sender, EventArgs e)
    {
        if (dataGridView1.SelectedRows.Count == 0)
        {
            MessageBox.Show("");
            return;
        }
        var index = dataGridView1.SelectedRows[0].Index;
        _students.Remove(_students[index]);
        dataGridView1.DataSource = null;
        dataGridView1.DataSource = _students;
        dataGridView1.Update();
    }

    private void AddButton_Click(object sender, EventArgs e)
    {
        var form = new AddStudentForm();
        if (form.ShowDialog() == DialogResult.OK)
        {
            _students.Add(form.GetEditedStudent());
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = _students;
            dataGridView1.Update();
        }
    }
}
