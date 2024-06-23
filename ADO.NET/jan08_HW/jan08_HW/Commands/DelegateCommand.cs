﻿using System;

namespace ExamWpfApp.Models.Commands;

public sealed class DelegateCommand : Command
{
    private static readonly Func<object, bool> DefaultCanExecute = _ => true;
    private readonly Action<object> executeAction;
    private readonly Func<object, bool> canExecuteFunc;

    public DelegateCommand(Action<object> executeAction) : this(executeAction, DefaultCanExecute)
    {
    }

    public DelegateCommand(Action<object> executeAction, Func<object, bool> canExecuteAction)
    {
        this.executeAction = executeAction;
        canExecuteFunc = canExecuteAction;
    }

    protected override void ExecuteCmd(object parameter)
    {
        executeAction(parameter);
    }

    protected override bool CanExecuteCmd(object parameter)
    {
        return canExecuteFunc(parameter);
    }
}