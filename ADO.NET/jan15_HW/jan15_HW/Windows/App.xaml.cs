using System.Data.Common;
using System.Data.SqlClient;
using System.Windows;
using Npgsql;

namespace jan15_HW.Windows
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static void RegisterFactories()
        {
            DbProviderFactories.RegisterFactory("Npgsql", NpgsqlFactory.Instance);
            DbProviderFactories.RegisterFactory("System.Data.SqlClient", SqlClientFactory.Instance);
        }

        private void App_OnStartup(object sender, StartupEventArgs e)
        {
            RegisterFactories();
            var window = new MainWindow();
            window.Show();
        }
    }
}