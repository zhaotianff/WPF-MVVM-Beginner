using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _12_Prism_MVVM_Usage.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string currentTime;

        public string CurrentTime
        {
            get => currentTime;
            set => SetProperty(ref currentTime, value);
        }

        private string msgContent;

        public string MsgContent
        {
            get => msgContent;
            set
            {
                SetProperty(ref msgContent, value);
                ShowMessageCommand.RaiseCanExecuteChanged();
            }
        }

        public DelegateCommand ShowMessageCommand { get; private set; }

        public CompositeCommand CompositeCommand { get; private set; }

        public DelegateCommand Command1 { get; private set; }
        public DelegateCommand Command2 { get; private set; }

        public MainWindowViewModel()
        {
            ShowMessageCommand = new DelegateCommand(ShowMessage, CanShowMessageExecute);


            Command1 = new DelegateCommand(Function1, CanCommand1Execute);
            Command2 = new DelegateCommand(Function2, CanCommand2Execute);

            //注册CompositeCommand
            CompositeCommand = new CompositeCommand();
            CompositeCommand.RegisterCommand(Command1);
            CompositeCommand.RegisterCommand(Command2);

            CurrentTime = DateTime.Now.ToString();
        }

        /// <summary>
        /// Command2 CanExecute回调
        /// </summary>
        /// <returns></returns>
        private bool CanCommand2Execute()
        {
            return true;
        }

        /// <summary>
        /// Command1 CanExecute回调
        /// </summary>
        /// <returns></returns>
        private bool CanCommand1Execute()
        {
            return true;
        }

        private void Function1()
        {
            //命令1回调
            System.Windows.MessageBox.Show("Command1");
        }

        private void Function2()
        {
            //命令2回调
            System.Windows.MessageBox.Show("Command2");
        }

        private void ShowMessage()
        {
            System.Windows.MessageBox.Show(MsgContent);
        }

        public bool CanShowMessageExecute()
        {
            return !string.IsNullOrEmpty(MsgContent);
        }
    }
}
