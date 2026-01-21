using _12_Prism_Ioc_Unity.Services;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _12_Prism_Ioc_Unity.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private IMessageService messageService;

        public MainWindowViewModel(IMessageService messageService)
        {
            this.messageService = messageService;

            System.Windows.MessageBox.Show( messageService.GetMessage());
        }
    }
}
