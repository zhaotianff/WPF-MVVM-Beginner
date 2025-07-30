using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace UseViewModelLocator.Command
{
    /// <summary>
    /// 一种命令，其唯一目的是通过调用委托将其功能传递给其他对象。
    /// CanExecute方法的默认返回值为"true"。
    /// 此类不允许在Execute和CanExecute回调方法中接受命令参数。
    /// 目前只用于演示，所以不增加支持传递参数的版本
    /// 正式使用时，会使用Prism/CommunityToolkit.MVVM等包
    /// </summary>
    public class RelayCommand : ICommand
    {
        /// <summary>
        /// 命令绑定的回调
        /// </summary>
        private readonly Action _execute;

        /// <summary>
        /// 命令是否可以被执行绑定的回调
        /// </summary>
        private readonly Func<bool> _canExecute;

        /// <summary>
        /// 当命令执行条件发生更改时触发
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }
            remove
            {
                if (_canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        /// <summary>
        ///  实例化RelayCommand
        /// </summary>
        /// <param name="execute"></param>
        public RelayCommand(Action execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// 实例化RelayCommand
        /// </summary>
        /// <param name="execute">命令绑定的回调</param>
        /// <param name="canExecute">命令是否可以被执行的回调</param>
        public RelayCommand(Action execute, Func<bool> canExecute)
        {
            if (execute == null)
            {
                throw new ArgumentNullException("execute");
            }

            _execute = execute;
            _canExecute = canExecute;
        }

        /// <summary>
        ///  触发CanExecuteChanged事件.
        /// </summary>
        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        /// <summary>
        /// 定义确定命令是否可以在其当前状态下执行的方法。
        /// </summary>
        /// <param name="parameter"></param>
        /// <returns></returns>
        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        /// <summary>
        /// 定义调用命令时要调用的方法。
        /// </summary>
        /// <param name="parameter"></param>
        public void Execute(object parameter)
        {
            _execute();
        }
    }
}
