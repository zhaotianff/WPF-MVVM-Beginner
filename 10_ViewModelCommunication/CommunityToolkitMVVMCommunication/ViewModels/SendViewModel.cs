using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CustomViewModelCommunication.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityToolkitMVVMCommunication.ViewModels
{
    public class SendViewModel: ObservableRecipient
    {
        public RelayCommand SendMessageCommand { get; private set; }

        public SendViewModel()
        {
            SendMessageCommand = new RelayCommand(SendMessage);
        }

        private void SendMessage()
        {
            this.Messenger.Send<DateTimeMessage>(new DateTimeMessage(new DateTimeDisplay() { DatetimeNow = DateTime.Now.ToString() }));
        }
    }
}
