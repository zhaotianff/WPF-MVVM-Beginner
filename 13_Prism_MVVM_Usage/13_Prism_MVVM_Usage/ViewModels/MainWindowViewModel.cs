using Prism.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Prism_MVVM_Usage.ViewModels
{
    public class MainWindowViewModel : Prism.Mvvm.BindableBase
    {
        private string currentDate;

        public string CurrentDate
        {
            get => currentDate;
            set => SetProperty(ref currentDate, value);
        }

        private string msgContent;

        public string MsgContent
        {
            get => msgContent;
            set => SetProperty(ref msgContent, value);
        }

        public DelegateCommand ShowMessageCommand { get; private set; }

        public MainWindowViewModel()
        {
            ShowMessageCommand = new DelegateCommand(ShowMessage, CanShowMessageExecute);

            CurrentDate = DateTime.Now.ToString();
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
