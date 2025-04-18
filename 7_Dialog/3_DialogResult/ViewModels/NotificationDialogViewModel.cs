using _3_DialogResult.Commands;
using _3_DialogResult.DialogService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3_DialogResult.ViewModels
{
    public class NotificationDialogViewModel : IMyDialog
    {
        public ICommand OkCommand { get; private set; }

        public ICommand CancelCommand { get; private set; }

        public NotificationDialogViewModel()
        {
            OkCommand = new RelayCommand(Ok);
            CancelCommand = new RelayCommand(Cancel);
        }

        public event Action<DialogResult> RequestClose;

        private void Cancel()
        {
            RaiseRequestClose(DialogResult.Cancel);
        }

        private void Ok()
        {
            RaiseRequestClose(DialogResult.Ok);
        }

        private void RaiseRequestClose(DialogResult dialogResult)
        {
            RequestClose?.Invoke(dialogResult);
        }  
    }
}
