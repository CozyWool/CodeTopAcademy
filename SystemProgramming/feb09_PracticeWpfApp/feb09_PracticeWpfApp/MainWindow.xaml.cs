using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows;

namespace feb09_PracticeWpfApp;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    private Process? _selectedProcess;
    private int _duplicatesCount;

    private Timer _timer;
    public int UpdateProcessListFrequency { get; set; }

    public ObservableCollection<Process> ProcessList { get; set; }

    public Process? SelectedProcess
    {
        get => _selectedProcess;
        set
        {
            if (value == null)
            {
                return;
            }
            _selectedProcess = value;
            ProcessInfoGrid.Visibility = Visibility.Visible;
            DuplicatesCount = ProcessList.Count(x => x.ProcessName == _selectedProcess.ProcessName);
            OnPropertyChanged();
        }
    }

    public int DuplicatesCount
    {
        get => _duplicatesCount;
        set
        {
            _duplicatesCount = value;
            OnPropertyChanged();
        }
    }

    public MainWindow()
    {
        UpdateProcessListFrequency = 1;
        // var tm = new TimerCallback(UpdateProcessList);
        // _timer = new Timer(tm, new(), 0, UpdateProcessListFrequency * 1000);
        UpdateProcessList(new());
        DataContext = this;
        InitializeComponent();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    private void KillProcessButton_OnClick(object sender, RoutedEventArgs e)
    {
        _selectedProcess?.Kill();
        Thread.Sleep(10); // без него не обновляется список после удаления, видимо слишком быстро происходят операции
        UpdateProcessList(new());
    }

    private void UpdateProcessList(object o) // объект нужен был для таймера
    {
        ProcessList = new ObservableCollection<Process>(Process.GetProcesses());
        OnPropertyChanged(nameof(ProcessList));
    }

    private void RefreshButton_OnClick(object sender, RoutedEventArgs e)
    {
        UpdateProcessList(new());
    }
}