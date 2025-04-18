using _3_DialogResult.Commands;
using _3_DialogResult.DialogService;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace _3_DialogResult.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private IDialogService dialogService;

        public event PropertyChangedEventHandler? PropertyChanged;

        private string dialogResultText;

        public string DialogResultText
        {
            get => dialogResultText;
            set
            {
                dialogResultText = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("DialogResultText"));
            }
        }

        public ICommand ShowDialogCommand { get; private set; }

        public MainWindowViewModel()
        {
            this.dialogService = DialogService.DialogService.GetInstance();

            ShowDialogCommand = new RelayCommand(ShowDialog);
        }

        private void ShowDialog()
        {
            dialogService.ShowNotificationDialog(ShowDialogResult);
        }

        private void ShowDialogResult(DialogResult dialogResult)
        {
            //显示结果
            this.DialogResultText = dialogResult.ToString();
        }
    }
}
