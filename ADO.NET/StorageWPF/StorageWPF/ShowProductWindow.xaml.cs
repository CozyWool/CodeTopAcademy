using System.Data;
using System.Windows;
using Npgsql;

namespace StorageWPF;

public partial class ShowProductWindow : Window
{
    private string _connectionString;

    public ShowProductWindow(string connectionString)
    {
        InitializeComponent();
        _connectionString = connectionString;
        UpdateDataSet();
    }

    private void UpdateDataSet()
    {
        var sortOrder = descCheckBox.IsChecked == true ? "DESC" : "ASC";
        var query = "SELECT p.id, p.name, p.product_type, s.amount FROM public.products p\n" +
                    "JOIN supplies s ON p.id = s.product_id\n" +
                    $"ORDER BY s.amount {sortOrder};";

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();
        var adapter = new NpgsqlDataAdapter(query, connection);
        var ds = new DataSet();
        adapter.Fill(ds);
        dg.ItemsSource = ds.Tables[0].DefaultView;
    }
    private void DescCheckBox_OnChecked(object sender, RoutedEventArgs e)
    {
        UpdateDataSet();
    }

    private void DescCheckBox_OnUnchecked(object sender, RoutedEventArgs e)
    {
        UpdateDataSet();
    }
}