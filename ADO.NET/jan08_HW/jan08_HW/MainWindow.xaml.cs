using System;
using System.ComponentModel;
using System.Data;
using System.Runtime.CompilerServices;
using System.Windows;
using ExamWpfApp.Models.Commands;
using Npgsql;

namespace jan08_HW
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private const string ConnectionString =
            "Host=localhost;Port=5432;Username=postgres;Password=qwerty;Database=jan08_HW";

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

        private NpgsqlConnection _connection;
        private DataView _queryResult;

        private bool CanExecuteAction(object _) => IsConnectionOpen;
        public Command DisconnectDatabaseCommand { get; set; }
        public Command ConnectDatabaseCommand { get; set; }
        public Command DoQueryCommand { get; set; }
        public Command ShowWithSelectedColorCommand { get; set; }
        public Command ShowWithCalorificValueCommand { get; set; }
        public Command ShowInCalorificRangeCommand { get; set; }

        public DataView QueryResult
        {
            get => _queryResult;
            set
            {
                _queryResult = value;
                OnPropertyChanged();
            }
        }


        public MainWindow()
        {
            InitializeComponent();


            DisconnectDatabaseCommand = new DelegateCommand(_ => DisconnectDatabase(), CanExecuteAction);
            ConnectDatabaseCommand = new DelegateCommand(_ => ConnectDatabase(), _ => !IsConnectionOpen);
            DoQueryCommand = new DelegateCommand((query) => DoQuery(query.ToString() ?? ""), CanExecuteAction);
            ShowWithSelectedColorCommand = new DelegateCommand(_ => ShowWithSelectedColor(), CanExecuteAction);
            ShowWithCalorificValueCommand =
                new DelegateCommand((param) =>
                {
                    if (bool.TryParse(param.ToString(), out var value))
                    {
                        ShowWithCalorificValue(value);
                    }
                }, CanExecuteAction);
            ShowInCalorificRangeCommand = new DelegateCommand((_) => ShowInCalorificRange(), CanExecuteAction);


            IsConnectionOpen = false;
            DataContext = this;
        }


        private void DoQuery(string query)
        {
            var adapter = new NpgsqlDataAdapter(query, _connection);
            var ds = new DataSet();
            adapter.Fill(ds);
            QueryResult = ds.Tables[0].DefaultView;
        }

        private void ShowWithSelectedColor()
        {
            var window = new SelectParamWindow("Укажите нужный цвет", 3);

            if (window.ShowDialog() != true) return;

            var query =
                $"SELECT \'{window.Param}\' AS \"Цвет\", COUNT(*) AS \"Кол-во заданного цвета\" FROM vegetables_and_fruits WHERE color = \'{window.Param}\'";
            // Пытался через параметр, но почему-то результат был 0, хотя все верно считывалось, в итоге схитрил интерполяцией
            //var p = new NpgsqlParameter("@p", window.Param);

            DoQuery(query);
        }

        private void ShowWithCalorificValue(bool isLess) // True - меньше указаноого False - больше
        {
            var window = new SelectParamWindow("Укажите величину калорийности:", 0);

            if (window.ShowDialog() != true) return;

            var query =
                $"SELECT * FROM vegetables_and_fruits WHERE calorific_value {(isLess ? '<' : '>')} \'{window.Param}\'";
            // Пытался через параметр, но почему-то результат был 0, хотя все верно считывалось, в итоге схитрил интерполяцией
            //var p = new NpgsqlParameter("@p", window.Param);

            DoQuery(query);
        }

        private void ShowInCalorificRange()
        {
            var window = new SelectTwoParamsWindow("Укажите диапазон калорийности", "От:", "До:", 0);

            if (window.ShowDialog() != true) return;

            var query =
                $"SELECT * FROM vegetables_and_fruits WHERE calorific_value BETWEEN {window.Param1} AND {window.Param2}";

            DoQuery(query);
        }

        // private void DoQueryWithParameter(string query, NpgsqlParameter p)
        // {
        //     var adapter = new NpgsqlDataAdapter(query, _connection);
        //     adapter.SelectCommand?.Parameters.Add(p);
        //
        //     var ds = new DataSet();
        //     adapter.Fill(ds);
        //     QueryResult = ds.Tables[0].DefaultView;
        // }

        private void ConnectDatabase()
        {
            _connection = new NpgsqlConnection(ConnectionString);
            try
            {
                _connection.Open();
                IsConnectionOpen = true;
            }
            catch (Exception)
            {
                MessageBox.Show("Произошла ошибка при подключении к базе данных!", "Ошибка!", MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }

            if (!IsConnectionOpen) return;

            MessageBox.Show("Успешное подключение к базе данных.", "Подключение успешно", MessageBoxButton.OK,
                MessageBoxImage.Information);
            DoQuery("SELECT * FROM vegetables_and_fruits;");
        }

        private void MainWindow_OnClosed(object? sender, EventArgs e)
        {
            DisconnectDatabase();
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
    }
}