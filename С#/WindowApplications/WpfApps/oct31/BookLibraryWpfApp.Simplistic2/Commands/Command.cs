using System;
using System.Windows.Input;

namespace BookLibraryWpfApp.Simplistics2.Commands;

public abstract class Command : ICommand
{
    public bool CanExecute(object? parameter)
    {
        return CanExecuteCommmand(parameter);
    }

    public void Execute(object? parameter)
    {
        ExecuteCommand(parameter);
    }

    public event EventHandler? CanExecuteChanged;


    public void RaiseCanExecuteChanged()
    {
        OnCanExecuteChanged(EventArgs.Empty);
    }

    protected virtual bool CanExecuteCommmand(object? parameter)
    {
        return true;
    }

    protected abstract void ExecuteCommand(object? parameter);

    protected virtual void OnCanExecuteChanged(EventArgs e)
    {
        CanExecuteChanged?.Invoke(this, e);
    }
}