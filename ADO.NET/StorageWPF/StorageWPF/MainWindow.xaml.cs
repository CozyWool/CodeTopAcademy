using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Npgsql;
using StorageWPF.Enums;

namespace StorageWPF
{
    public partial class MainWindow : Window
    {
        private string _connectionString;
        
        public MainWindow()
        {
            InitializeComponent();
            _connectionString = ConfigurationManager.ConnectionStrings["MyConnectionString"].ConnectionString;

            LoadData();
        }

        private void LoadData()
        {
            const string productsTableName = "products";
            const string query = "SELECT * FROM products";
            
            using var connection = new NpgsqlConnection(_connectionString);
            connection.Open();
            var adapter = new NpgsqlDataAdapter(query, connection);
            var ds = new DataSet();
            adapter.Fill(ds, productsTableName);
            dg.ItemsSource = ds.Tables[productsTableName]?.DefaultView;
        }

        private void ProductsType_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new ShowDataWindow(ActionTypes.ProductType, _connectionString);
            window.Show();
        }

        private void Suppliers_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new ShowDataWindow(ActionTypes.Suppliers, _connectionString);
            window.Show();
        }

        private void MinMaxProduct_OnClick(object sender, RoutedEventArgs e)
        {
            var window = new ShowProductWindow(_connectionString);
            window.Show();
        }
    }
}