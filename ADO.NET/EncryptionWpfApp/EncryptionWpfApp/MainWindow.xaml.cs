using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace TransWpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private SqlConnection _connection;
    private SqlDataAdapter _dataAdapter;
    private DataSet _set;
    private SqlCommandBuilder _cmd;
    private DataTable _table;
    private string _connectionString = "";

    public MainWindow()
    {
        InitializeComponent();
        _connectionString = ConfigurationManager.ConnectionStrings["MyLocalDb"].ConnectionString;
        _connection = new SqlConnection(_connectionString);

        var aesCrypto = Aes.Create();
        
        aesCrypto.GenerateKey();
        aesCrypto.GenerateIV();
        var key = aesCrypto.Key;
        var iv = aesCrypto.IV;
        var str = Convert.ToBase64String(key) + Environment.NewLine + Convert.ToBase64String(iv);
        File.WriteAllText("test", str);
        
        ///
        var aes2 = Aes.Create();
        var encryptor = aes2.CreateEncryptor(key, iv);
        var decryptor = aes2.CreateDecryptor(key, iv);

        using var msEncrypt = new MemoryStream();
        using var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write);
        using (var swEncrypt = new StreamWriter(csEncrypt))
        {
            //Write all data to the stream
            swEncrypt.Write(_connectionString);
        }
        
        var encrypted = msEncrypt.ToArray();
        var connectionStringEncrypted = Convert.ToBase64String(encrypted);
        MessageBox.Show(connectionStringEncrypted);
    }

    private void FillButton_OnClick(object sender, RoutedEventArgs e)
    {
        try
        {
            _connection = new SqlConnection(_connectionString);
            _set = new DataSet();
            var sqlQuery = QueryTextBox.Text;
            _dataAdapter = new SqlDataAdapter(sqlQuery, _connection);

            _cmd = new SqlCommandBuilder(_dataAdapter);
            Debug.WriteLine(_cmd.GetInsertCommand().CommandText);
            Debug.WriteLine(_cmd.GetUpdateCommand().CommandText);
            Debug.WriteLine(_cmd.GetDeleteCommand().CommandText);

            _dataAdapter.Fill(_set, "Books");
            DataViewManager manager = new DataViewManager(_set);
            manager.DataViewSettings["Books"].RowFilter = "id < 30";
            manager.DataViewSettings["Books"].Sort = "Name desc";
            DataView view = manager.CreateDataView(_set.Tables["Books"]);

            Dg.ItemsSource = view;
        }
        catch (Exception ex)
        {

        }
        finally
        {
            _connection.Close();
        }

    }

    private void UpdateButton_Click(object sender, RoutedEventArgs e)
    {
        _dataAdapter.Update(_set, "Books");
    }

    private void TransactionButton_Click(object sender, RoutedEventArgs e)
    {
        _connection = new SqlConnection(_connectionString);
        var cmd = _connection.CreateCommand();
        SqlTransaction transaction = null;
        try
        {
            _connection.Open();
            transaction = _connection.BeginTransaction();
            cmd.Transaction = transaction;

            cmd.CommandText = "CREATE TABLE tmp(id INT NOT NULL PRIMARY KEY, field1 VARCHAR(20));";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO tmp(id, field1) VALUES(1, 'dfgdfg');";
            cmd.ExecuteNonQuery();

            cmd.CommandText = "INSERT INTO tmp(id, field1) VALUES(2, 'qwerty');";
            cmd.ExecuteNonQuery();

            transaction.Commit();
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
            transaction?.Rollback();
        }
        finally
        {
            _connection?.Close();
        }
    }

    private void AsyncButton1_Click(object sender, RoutedEventArgs e)
    {
        _connection = new SqlConnection(_connectionString);
        var cmd = _connection.CreateCommand();
        cmd.CommandText = "WAITFOR DELAY '00:00:05'; SELECT * FROM Books;";
        cmd.CommandTimeout = 30;
        try
        {
            _connection.Open();
            var ar = cmd.BeginExecuteReader(GetDataCallback, cmd);
            MessageBox.Show("Start working...");
            /// some code....(10 - 30 code lines)

            //ar.AsyncWaitHandle.WaitOne();

            /// need data reader
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void GetDataCallback(IAsyncResult ar)
    {
        SqlDataReader reader = null;
        try
        {
            var sb = new StringBuilder();
            var cmd = ar.AsyncState as SqlCommand;
            reader = cmd?.EndExecuteReader(ar) ?? throw new NullReferenceException();
            _table = new DataTable();
            var line = 0;

            do
            {
                while (reader.Read())
                {
                    if (line == 0)
                    {
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            _table.Columns.Add(reader.GetName(i));
                        }

                        line++;
                    }

                    var row = _table.NewRow();
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i];
                    }

                    _table.Rows.Add(row);
                }
            } while (reader.NextResult());

            Dispatcher.Invoke(() => { Dg.ItemsSource = _table.DefaultView; });
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
        finally
        {
            reader?.Close();
        }
    }

    private void AsyncButton2_Click(object sender, RoutedEventArgs e)
    {
        _connection = new SqlConnection(_connectionString);
        var cmd = _connection.CreateCommand();
        cmd.CommandText = "WAITFOR DELAY '00:00:05'; SELECT * FROM Books;";
        cmd.CommandTimeout = 30;
        try
        {
            _connection.Open();
            var ar = cmd.BeginExecuteReader();
            var handle = ar.AsyncWaitHandle;
            MessageBox.Show("Start working...");
            if (handle.WaitOne(TimeSpan.FromSeconds(10)))
            {
                GetData(cmd, ar);
            }
            else
            {
                MessageBox.Show("Time limit exceeded");
            }
            /// some code....(10 - 30 code lines)

            //ar.AsyncWaitHandle.WaitOne();

            /// need data reader
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.Message);
        }
    }

    private void GetData(SqlCommand cmd, IAsyncResult ar)
    {
        SqlDataReader reader = null;
        try
        {
            reader = cmd.EndExecuteReader(ar);
            _table = new DataTable();
            var line = 0;
            do
            {
                while (reader.Read())
                {
                    if (line == 0)
                    {
                        for (var i = 0; i < reader.FieldCount; i++)
                        {
                            _table.Columns.Add(reader.GetName(i));
                        }

                        line++;
                    }

                    var row = _table.NewRow();
                    for (var i = 0; i < reader.FieldCount; i++)
                    {
                        row[i] = reader[i];
                    }

                    _table.Rows.Add(row);
                }
            } while (reader.NextResult());

            Dispatcher.Invoke(() => { Dg.ItemsSource = this._table.DefaultView; });
        }
        catch (Exception ex)
        {
            MessageBox.Show("From GetData 1:" + ex.Message);
        }
        finally
        {
            reader?.Close();
        }
    }

    private void AsyncFile_Click(object sender, RoutedEventArgs e)
    {

    }
}