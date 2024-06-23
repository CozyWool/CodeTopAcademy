using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using jan15_HW.Commands;

namespace jan15_HW.Windows
{
    public partial class MainWindow : Window, INotifyPropertyChanged, IDisposable
    {
        private DbProviderFactory _factory;

        private bool _isConnectionOpen;

        public bool IsConnectionOpen
        {
            get => _isConnectionOpen;
            set
            {
                _isConnectionOpen = value;
                OnPropertyChanged();
            }
        }

        private DbConnection _connection;
        private DataView _queryResult;
        private Stopwatch _stopwatch;

        private bool CanExecuteAction(object _) => IsConnectionOpen;
        private bool CanExecuteConnection(object _) => !IsConnectionOpen && ProviderName.Length > 0;

        private bool CanExecuteDeleteRow(object _) =>
            CanExecuteAction(_) && DataBaseGrid.SelectedIndex != -1 && !DataBaseGrid.IsReadOnly;

        public Command DisconnectDatabaseCommand { get; set; }
        public Command ConnectDatabaseCommand { get; set; }
        public Command DoQueryCommand { get; set; }
        public Command ShowAllDataCommand { get; set; }
        public Command ShowWithSelectedColorCommand { get; set; }
        public Command ShowWithCalorificValueCommand { get; set; }
        public Command ShowInCalorificRangeCommand { get; set; }
        public Command UpdateDbCommand { get; set; }
        public Command DeleteRowCommand { get; set; }
        public string ProviderName { get; set; }
        public DataSet Data { get; set; }

        public DataView QueryResult
        {
            get => _queryResult;
            set
            {
                _queryResult = value;
                OnPropertyChanged();
            }
        }

        public List<string> Factories { get; set; }

        public TimeSpan ElapsedTime => _stopwatch.Elapsed;

        public MainWindow()
        {
            InitializeComponent();
            Factories = new List<string>();
            ProviderName = "";
            Data = new DataSet();
            _stopwatch = new Stopwatch();

            DisconnectDatabaseCommand = new DelegateCommand(_ => CalculateTime(DisconnectDatabase), CanExecuteAction);
            ConnectDatabaseCommand =
                new DelegateCommand(_ => CalculateTime(ExecuteConnectDataBase), CanExecuteConnection);
            DoQueryCommand =
                new DelegateCommand(query => CalculateTime(DoQuery, query.ToString() ?? ""), CanExecuteAction);
            ShowAllDataCommand = new DelegateCommand(_ => CalculateTime(ExecuteShowAllData), CanExecuteAction);
            ShowWithSelectedColorCommand =
                new DelegateCommand(_ => CalculateTime(ShowWithSelectedColor), CanExecuteAction);
            ShowWithCalorificValueCommand =
                new DelegateCommand(param =>
                {
                    if (bool.TryParse(param.ToString(), out var value))
                    {
                        CalculateTime(ShowWithCalorificValue, value);
                    }
                }, CanExecuteAction);
            ShowInCalorificRangeCommand =
                new DelegateCommand(_ => CalculateTime(ShowInCalorificRange), CanExecuteAction);
            UpdateDbCommand = new DelegateCommand(_ => CalculateTime(ExecuteUpdateDb), CanExecuteAction);
            DeleteRowCommand = new DelegateCommand(_ => CalculateTime(ExecuteDeleteRow), CanExecuteDeleteRow);


            IsConnectionOpen = false;
            DataContext = this;

            GetAllProviders();
        }

        private void CalculateTime(Action action)
        {
            _stopwatch.Reset();
            _stopwatch.Start();
            action();
            OnPropertyChanged(nameof(ElapsedTime));
            _stopwatch.Stop();
        }

        private void CalculateTime<T>(Action<T> action, T parameter)
        {
            _stopwatch.Reset();
            _stopwatch.Start();
            action(parameter);
            OnPropertyChanged(nameof(ElapsedTime));
            _stopwatch.Stop();
        }

        private async void ExecuteConnectDataBase()
        {
            await ConnectDatabaseAsync();
        }

        private async void ExecuteShowAllData()
        {
            await ShowAllDataAsync();
        }

        private async void ExecuteUpdateDb()
        {
            await UpdateDbAsync();
        }

        private async void ExecuteDeleteRow()
        {
            await DeleteRowAsync();
        }

        private void DeleteRow()
        {
            Dispatcher.Invoke(() =>
            {
                ((DataRowView) DataBaseGrid.SelectedItem).Delete();
                QueryResult = Data.Tables[0].DefaultView;
            });

            UpdateDb();
        }

        private async Task DeleteRowAsync()
        {
            var task = Task.Run(DeleteRow);
            await task;
        }

        private void UpdateDb()
        {
            Dispatcher.Invoke(() =>
            {
                var adapter = CreateAdapter("SELECT * FROM vegetables_and_fruits");
                var commandBuilder = _factory.CreateCommandBuilder();
                commandBuilder.DataAdapter = adapter;

                adapter.Update(Data.Tables[0]);
            });
            ShowAllData();
        }

        private async Task UpdateDbAsync()
        {
            var task = Task.Run(UpdateDb);
            await task;
        }


        private void GetAllProviders()
        {
            Factories.Clear();
            foreach (DataRow row in DbProviderFactories.GetFactoryClasses().Rows)
            {
                Factories.Add(row["InvariantName"].ToString());
            }

            OnPropertyChanged(nameof(Factories));
        }


        private void DoQuery(string query)
        {
            Dispatcher.Invoke(() =>
            {
                DataBaseGrid.IsReadOnly = true;
                var adapter = CreateAdapter(query);

                Data = new DataSet();
                adapter.Fill(Data);
                QueryResult = Data.Tables[0].DefaultView;
            });
        }

        private void DoQuery(DbCommand cmd)
        {
            Dispatcher.Invoke(() =>
            {
                DataBaseGrid.IsReadOnly = true;
                var adapter = CreateAdapter(cmd);

                Data = new DataSet();
                adapter.Fill(Data);
                QueryResult = Data.Tables[0].DefaultView;
            });
        }

        private void ShowAllData()
        {
            Dispatcher.Invoke(() =>
            {
                const string query = "SELECT * FROM vegetables_and_fruits";
                DoQuery(query);
                DataBaseGrid.IsReadOnly = false;
            });
        }

        private async Task ShowAllDataAsync()
        {
            var task = Task.Run(ShowAllData);
            await task;
        }

        private void ShowWithSelectedColor()
        {
            var window = new SelectParamWindow("Укажите нужный цвет", 3);

            if (window.ShowDialog() != true) return;

            const string query =
                "SELECT @p1 AS \"Цвет\", COUNT(*) AS \"Кол-во заданного цвета\" FROM vegetables_and_fruits WHERE color = @p1";
            var p1 = _factory.CreateParameter();
            p1.ParameterName = "@p1";
            p1.Value = window.Param;

            var cmd = _factory.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = query;
            cmd.Parameters.Add(p1);
            DoQuery(cmd);
        }

        private void ShowWithCalorificValue(bool isLess) // True - меньше указаноого False - больше
        {
            var window = new SelectParamWindow("Укажите величину калорийности:", 0);

            if (window.ShowDialog() != true) return;

            var query =
                $"SELECT * FROM vegetables_and_fruits WHERE calorific_value {(isLess ? '<' : '>')} @p1";
            var p1 = _factory.CreateParameter();
            p1.ParameterName = "@p1";
            p1.Value = Convert.ToInt32(window.Param);


            var cmd = _factory.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = query;
            cmd.Parameters.Add(p1);
            DoQuery(cmd);
        }

        private void ShowInCalorificRange()
        {
            var window = new SelectTwoParamsWindow("Укажите диапазон калорийности", "От:", "До:", 0);

            if (window.ShowDialog() != true) return;

            const string query = "SELECT * FROM vegetables_and_fruits WHERE calorific_value BETWEEN @p1 AND @p2";
            var p1 = _factory.CreateParameter();
            p1.ParameterName = "@p1";
            p1.Value = Convert.ToInt32(window.Param1);

            var p2 = _factory.CreateParameter();
            p2.ParameterName = "@p2";
            p2.Value = Convert.ToInt32(window.Param2);

            var cmd = _factory.CreateCommand();
            cmd.Connection = _connection;
            cmd.CommandText = query;
            cmd.Parameters.Add(p1);
            cmd.Parameters.Add(p2);
            DoQuery(cmd);
        }


        private async Task ConnectDatabaseAsync()
        {
            var task = Task.Run(() =>
            {
                if (IsConnectionOpen) _connection.Dispose();

                try
                {
                    _connection = _factory.CreateConnection();
                    _connection.ConnectionString =
                        GetConnectionStringByProvider(ProviderName);
                    IsConnectionOpen = true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Произошла ошибка при подключении к базе данных!", "Ошибка!", MessageBoxButton.OK,
                        MessageBoxImage.Error);
                }

                if (!IsConnectionOpen) return;

                MessageBox.Show("Успешное подключение к базе данных.", "Подключение успешно", MessageBoxButton.OK,
                    MessageBoxImage.Information);
            });
            await task;
            await ShowAllDataAsync();
        }


        private static string? GetConnectionStringByProvider(string? providerName)
        {
            var settings = ConfigurationManager.ConnectionStrings;

            return settings == null
                ? null
                : (from ConnectionStringSettings s in settings
                    where s.ProviderName == providerName
                    select s.ConnectionString).FirstOrDefault();
        }

        private void DisconnectDatabase()
        {
            if (!IsConnectionOpen) return;

            _connection.Dispose();
            IsConnectionOpen = false;
            MessageBox.Show("Отключение от базы данных.", "Отключение", MessageBoxButton.OK,
                MessageBoxImage.Information);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void Dispose()
        {
            _connection.Dispose();
            _queryResult.Dispose();
            Data.Dispose();
        }

        private DbDataAdapter CreateAdapter(string query)
        {
            var adapter = _factory.CreateDataAdapter();
            adapter.SelectCommand = _connection.CreateCommand();
            adapter.SelectCommand.CommandText = query;
            return adapter;
        }

        private DbDataAdapter CreateAdapter(DbCommand cmd)
        {
            var adapter = _factory.CreateDataAdapter();
            adapter.SelectCommand = cmd;
            return adapter;
        }

        private void Providers_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            _factory = DbProviderFactories.GetFactory(ProviderName);
            CalculateTime(ExecuteConnectDataBase);
        }
    }
}