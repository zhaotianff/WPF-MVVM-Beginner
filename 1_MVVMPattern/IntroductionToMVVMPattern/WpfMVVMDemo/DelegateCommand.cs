﻿
using System;
using System.Diagnostics.CodeAnalysis;
using System.Windows.Input;

namespace WpfMVVMDemo
{
    public class DelegateCommand<T> : ICommand
    {
        private readonly Func<T, bool> canExecuteMethod;
        private readonly Action<T> executeMethod;
        private bool isExecuting;

        public DelegateCommand(Action<T> executeMethod)
            : this(executeMethod, null)
        {
        }

        public DelegateCommand(Action<T> executeMethod, Func<T, bool> canExecuteMethod)
        {
            if ((executeMethod == null) && (canExecuteMethod == null))
            {
                throw new ArgumentNullException("executeMethod", @"Execute Method cannot be null");
            }
            this.executeMethod = executeMethod;
            this.canExecuteMethod = canExecuteMethod;
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        bool ICommand.CanExecute(object parameter)
        {
            return !isExecuting && CanExecute((T)parameter);
        }

        void ICommand.Execute(object parameter)
        {
            isExecuting = true;
            try
            {
                RaiseCanExecuteChanged();
                Execute((T)parameter);
            }
            finally
            {
                isExecuting = false;
                RaiseCanExecuteChanged();
            }
        }

        public bool CanExecute(T parameter)
        {
            if (canExecuteMethod == null)
                return true;

            return canExecuteMethod(parameter);
        }

        public void Execute(T parameter)
        {
            executeMethod(parameter);
        }
    }

    public class DelegateCommand : DelegateCommand<object>
    {
        public DelegateCommand(Action executeMethod) : base(o => executeMethod())
        {
        }

        public DelegateCommand(Action executeMethod, Func<bool> canExecuteMethod) : base(o => executeMethod(), o => canExecuteMethod())
        {
        }
    }
}