using System;

namespace BookLibraryWpfApp.Simplistics2.Commands;

public sealed class DelegateCommand : Command
{
    private static readonly Func<object?, bool> DefaultCanExecute = _ => true;
    private readonly Action<object?> _executeAction;
    private readonly Func<object?, bool> _canExecuteAction;

    public DelegateCommand(Action<object?> executeAction) : this(executeAction, DefaultCanExecute)
    {
    }

    public DelegateCommand(Action<object?> executeAction, Func<object?, bool> canExecuteAction)
    {
        _executeAction = executeAction;
        _canExecuteAction = canExecuteAction;
    }

    protected override void ExecuteCommand(object? parameter)
    {
        _executeAction(parameter);
    }

    protected override bool CanExecuteCommmand(object? parameter)
    {
        return _canExecuteAction(parameter);
    }
}