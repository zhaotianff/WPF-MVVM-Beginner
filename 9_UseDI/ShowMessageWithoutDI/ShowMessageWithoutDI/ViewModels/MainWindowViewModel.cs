using ShowMessageWithoutDI.Command;
using ShowMessageWithoutDI.Services;
using ShowMessageWithoutDI.Services.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShowMessageWithoutDI.ViewModels
{
    public class MainWindowViewModel
    {
        public RelayCommand ShowMessageCommand { get; private set; }

        private IMyService service;

        public MainWindowViewModel()
        {
            service = new MyService();
            ShowMessageCommand = new RelayCommand(ShowMessage);
        }

        private void ShowMessage()
        {
            this.service.ShowMessage();
        }
    }
}
