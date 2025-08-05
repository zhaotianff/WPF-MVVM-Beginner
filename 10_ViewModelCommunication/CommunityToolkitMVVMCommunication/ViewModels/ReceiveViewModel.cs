using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using CustomViewModelCommunication.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommunityToolkitMVVMCommunication.ViewModels
{
    public class ReceiveViewModel : ObservableRecipient
    {
        private ObservableCollection<string> messageList = new ObservableCollection<string>();

        public ObservableCollection<string> MessageList
        {
            get
            {
                return messageList;
            }

            set
            {
                SetProperty(ref messageList, value);
            }
        }

        public ReceiveViewModel()
        {
            this.Messenger.Register<ReceiveViewModel, DateTimeMessage>(this, OnReceiveDateTimeChangedMessage);
        }

        private void OnReceiveDateTimeChangedMessage(ReceiveViewModel recipient, DateTimeMessage message)
        {
            messageList.Add(message.Value.DatetimeNow);
        }
    }
}
