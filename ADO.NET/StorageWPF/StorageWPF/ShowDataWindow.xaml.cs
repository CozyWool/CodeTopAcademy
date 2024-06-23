using System;
using System.Configuration;
using System.Data;
using System.Windows;
using Npgsql;
using StorageWPF.Enums;

namespace StorageWPF;

public partial class ShowDataWindow : Window
{
    private readonly ActionTypes _actionType;
    private string _connectionString;

    public ShowDataWindow(ActionTypes actionType, string connectionString)
    {
        InitializeComponent();
        
        _actionType = actionType;
        _connectionString = connectionString;

        using var connection = new NpgsqlConnection(_connectionString);
        connection.Open();

        var query = actionType switch
        {
            ActionTypes.ProductType => "SELECT DISTINCT product_type FROM products;",
            ActionTypes.Suppliers => "SELECT * FROM suppliers;",
            _ => throw new ArgumentOutOfRangeException(nameof(actionType), actionType, null)
        };

        var adapter = new NpgsqlDataAdapter(query, connection);
        var ds = new DataSet();
        adapter.Fill(ds);
        dg.ItemsSource = ds.Tables[0]?.DefaultView;
        
    }
}