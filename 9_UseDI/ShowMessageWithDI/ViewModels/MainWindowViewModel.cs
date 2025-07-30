using ShowMessageWithDI.Services.Contract;
using ShowMessageWithDI.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShowMessageWithDI.Command;

namespace ShowMessageWithDI.ViewModels
{
    public class MainWindowViewModel
    {
        public RelayCommand ShowMessageCommand { get; private set; }

        private IMyService service;

        public MainWindowViewModel(IMyService myService)
        {
            this.service = myService;
            ShowMessageCommand = new RelayCommand(ShowMessage);
        }

        private void ShowMessage()
        {
            this.service.ShowMessage();
        }
    }
}
