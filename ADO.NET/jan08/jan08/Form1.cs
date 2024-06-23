using Npgsql;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Text;

namespace jan08;

public partial class Form1 : Form
{
    private readonly string ConnectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString
        ?? throw new Exception("Connection string error");
    private const string AllStudentsQuery = "SELECT stud.*, subj.name, marks.mark FROM students stud\r\nJOIN marks ON marks.student_id = stud.id\r\nJOIN subjects subj ON marks.subject_id = subj.id;";

    public Form1()
    {
        InitializeComponent();
    }

    private void button1_Click(object sender, EventArgs e)
    {
        NpgsqlConnection connection = new NpgsqlConnection(ConnectionString);
        connection.Open();

        var sql = "SELECT version()";
        NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sql, connection);
        var version = npgsqlCommand.ExecuteScalar().ToString();


        MessageBox.Show(version);

        connection.Close();
    }

    private void button2_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
        NpgsqlConnection connection = new NpgsqlConnection(ConnectionString);
        connection.Open();

        var sql = AllStudentsQuery;
        NpgsqlCommand npgsqlCommand = new NpgsqlCommand(sql, connection);
        using (var reader = npgsqlCommand.ExecuteReader())
        {
            while (reader.Read())
            {
                sb.AppendLine($"{reader.GetString("name")} : {reader.GetString(3)} - {reader.GetInt64("mark")}");
            }
        }

        MessageBox.Show(sb.ToString());

        connection.Close();
    }

    private void button3_Click(object sender, EventArgs e)
    {
        var sb = new StringBuilder();
        NpgsqlConnection connection = new NpgsqlConnection(ConnectionString);
        connection.Open();

        var adapter = new NpgsqlDataAdapter(AllStudentsQuery, connection);

        adapter.SelectCommand = new NpgsqlCommand(AllStudentsQuery, connection);
        var ds = new DataSet();
        adapter.Fill(ds);
        dataGridView1.DataSource = ds.Tables[0];

        connection.Close();
    }
}
