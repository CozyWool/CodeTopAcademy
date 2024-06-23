using System.ComponentModel;
using System.Runtime.CompilerServices;
using CommandWpfApp.Commands;

namespace CommandWpfApp;

public class DataSource : INotifyPropertyChanged
{
    private readonly Command _redCommand;
    private readonly Command _greenCommand;
    private readonly Command _blueCommand;

    private string _selectedColor = "Black";

    public Command RedCommand => _redCommand;
    public Command GreenCommand => _greenCommand;
    public Command BlueCommand => _blueCommand;

    public string SelectedColor
    {
        get => _selectedColor;
        set
        {
            _selectedColor = value;
            OnPropertyChanged();
        }
    }

    public DataSource()
    {
        _redCommand = new DelegateCommand((_) => SelectedColor = "Red",
            (_) => _selectedColor != "Red");
        _greenCommand = new DelegateCommand((_) => SelectedColor = "Green",
            (_) => _selectedColor != "Green");
        _blueCommand = new DelegateCommand((_) => SelectedColor = "Blue",
            (_) => _selectedColor != "Blue");

        PropertyChanged += DataSource_PropertyChanged;
    }

    private void DataSource_PropertyChanged(object? sender, PropertyChangedEventArgs e)
    {
        if (e.PropertyName != nameof(SelectedColor)) return;
        _redCommand.RaiseCanExecuteChanged();
        _greenCommand.RaiseCanExecuteChanged();
        _blueCommand.RaiseCanExecuteChanged();
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
}