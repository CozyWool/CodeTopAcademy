using Npgsql;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.OleDb;
using System.Data.SqlClient;
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

namespace ProvidersWpf;
public partial class MainWindow : Window
{
    private DbConnection connection;
    private DbProviderFactory factory;

    public MainWindow()
    {
        InitializeComponent();
        StartScript.IsEnabled = false;
    }

    private void StartScript_OnClick(object sender, RoutedEventArgs e)
    {
        connection.ConnectionString = ProviderNameTextBox.Text;
        var adapter = factory.CreateDataAdapter();
        adapter.SelectCommand = connection.CreateCommand();
        adapter.SelectCommand.CommandText = ScriptTextBox.Text;

        var table = new DataTable();
        adapter.Fill(table);

        Dg.ItemsSource = null;
        Dg.ItemsSource = table.DefaultView;
    }

    private void GetAllProviders_OnClick(object sender, RoutedEventArgs e)
    {
        DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
        DbProviderFactories.RegisterFactory("Npgsql", NpgsqlFactory.Instance);
        DbProviderFactories.RegisterFactory("System.DataOleDb", OleDbFactory.Instance);
        DataTable t = DbProviderFactories.GetFactoryClasses();
        Dg.ItemsSource = t.DefaultView;

        CbProviders.Items.Clear();
        foreach (DataRow row in t.Rows)
        {
            CbProviders.Items.Add(row["InvariantName"]);
        }
    }

    private void CbProviders_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        factory = DbProviderFactories.GetFactory(CbProviders.SelectedItem.ToString());
        connection = factory.CreateConnection();
        ProviderNameTextBox.Text = GetConnectionStringByProvider(CbProviders.SelectedItem.ToString());
    }

    private static string? GetConnectionStringByProvider(string? providerName)
    {
        ConnectionStringSettingsCollection settings = ConfigurationManager.ConnectionStrings;
        
        if (settings == null) return null;

        foreach (ConnectionStringSettings s in settings)
        {
            if (s.ProviderName == providerName)
            {
                return s.ConnectionString;
            }
        }

        return null;
    }

    private void ScriptTextBox_TextChanged(object sender, TextChangedEventArgs e)
    {
        StartScript.IsEnabled = ScriptTextBox.Text.Length > 0;
    }
}